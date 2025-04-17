import sys
from PyQt6 import uic
from PyQt6.QtWidgets import QApplication, QMainWindow, QMessageBox, QWidget, QVBoxLayout, QFileDialog, QTextEdit, QPushButton
from PyQt6.QtGui import QRegularExpressionValidator
from PyQt6.QtCore import QRegularExpression

M = 24
bit_list = [24, 4, 3, 1]

#x^24 + x^4 + x^3 + x + 1

class App(QMainWindow):
    def __init__(self):
        super().__init__()
        uic.loadUi('Lab2.ui', self)
        self.registerStateEdit.textChanged.connect(self.filter_input)
        self.LengthRegister.setText(str(M))
        self.decipherButton.setEnabled(self.can_click())
        self.plainTextFromFile = ""
        self.decipheredText = ""
        #self.saveAction.setEnabled(self.can_save)

        self.openAction.triggered.connect(self.open_file)
        self.saveAction.triggered.connect(self.save_file)
        self.decipherButton.clicked.connect(self.decipher_button_click)

    def filter_input(self):
        text = self.registerStateEdit.toPlainText()
        filtered_text = ''.join(ch for ch in text if ch in "01")
        if text != filtered_text:
            self.registerStateEdit.setText(filtered_text)
        self.decipherButton.setEnabled(self.can_click())


    def can_click(self):
        return len(self.registerStateEdit.toPlainText()) == M and (self.plainTextEdit.toPlainText() != "") and (self.registerStateEdit.toPlainText() != "")

    def open_binary_file(self, file_name):
        binary_string = ""
        if file_name:
            try:
                with open(file_name, "rb") as file:
                    binary_data = file.read()
                    binary_data = binary_data.decode("utf-8")
                    binary_string = ''.join(f'{byte:08b}' for byte in binary_data)
            except Exception as e:
                    print(f"Ошибка при чтении файла: {e}")
            return binary_string

    def open_file(self):
        file_name, _ = QFileDialog.getOpenFileName(
            self, "Выберите файл", "", "Все файлы (*.*)"
        )
        if file_name:
            try:
                with open(file_name, "rb") as file:
                    binary_data = file.read()

                    binary_string = ''.join(f'{byte:08b}' for byte in binary_data)
                    if len(binary_string) > 240:  # 15 байт * 8 бит = 120 бит (нужно 2 части: 120 + 120 = 240)
                        formatted_string = f"Первые 15 байт: {binary_string[:120]}\n...\nПоследние 15 байт: {binary_string[-120:]}"
                    else:
                        formatted_string = f"{binary_string}"
                    self.plainTextFromFile = binary_string
                    self.plainTextEdit.setText(formatted_string)
                    self.decipherButton.setEnabled(self.can_click())
            except Exception as e:
                print(f"Ошибка при чтении файла: {e}")



    def save_file(self):
        #binary_data = self.decipheredText.encode('utf-8')
        binary_data = bytes(int(self.decipheredText[i:i + 8], 2) for i in range(0, len(self.decipheredText), 8))
        file_name, _ = QFileDialog.getOpenFileName(
            self, "Выберите файл"
        )
        if file_name:
            with open(file_name, "wb") as file:
                file.write(binary_data)

    def can_save(self):
        return self.decipheredKeyEdit.toPlainText() != ""

    def decipher_button_click(self):
        if self.plainTextFromFile == "":
            filtered_text = ''.join(ch for ch in self.plainTextEdit.toPlainText() if ch in "01")
            plain_text = filtered_text
        else:
            plain_text = self.plainTextFromFile
        register_state = self.registerStateEdit.toPlainText()

        key = generate_key(plain_text, bit_list, register_state)
        deciphered_text = decipher_plaintext(plain_text, key)
        if len(deciphered_text) > 240:  # 15 байт * 8 бит = 120 бит (нужно 2 части: 120 + 120 = 240)
            deciphered_string = f"Первые 15 байт: {deciphered_text[:120]}\n...\nПоследние 15 байт: {deciphered_text[-120:]}"
        else:
            deciphered_string = f"Все данные: {deciphered_text}"
        self.decipheredText = deciphered_text
        key_str = "".join(map(str, key))

        if len(key_str ) > 240:
            key_string = f"Первые 15 байт: {key_str [:120]}\n...\nПоследние 15 байт: {key_str [-120:]}"
        else:
            key_string = f"Весь ключ: {key_str[:len(plain_text)] }"
        self.decipheredKeyEdit.setText(key_string)

        self.decipheredTextEdit.setText(deciphered_string)
        self.plainTextFromFile = ""
   #     self.saveAction.setEnabled(self.can_save)

#x^23 + x^5 + 1
#23 - длина, учавствуют 23 и 5



def generate_key(plain_text, bit_list, state ):
    state_list = list(map(int, state))
    key = state_list.copy()

    ind1, ind2, ind3, ind4 =  bit_list
    ind1, ind2, ind3, ind4 = M - ind1, M - ind2, M - ind3, M- ind4
    key_length = len(plain_text) - len(key)
    for i in range(key_length):
        number = state_list[ind1 ] ^ state_list[ind2 ] ^ state_list [ind3] ^ state_list [ind4 ]
        key.append(number)
        state_list.append(number)
        state_list = state_list[1:]  # сдвигаю на 1 влево
    return key

def decipher_plaintext(plain_text, key):
    plain_text_list = list(map(int, plain_text))
    key_list = list(map(int, key))
    deciphered_text_list = []
    for i in range(len(plain_text)):
        deciphered_text_list.append(key_list[i] ^ plain_text_list[i])
    deciphered_text = "".join(map(str,deciphered_text_list))
    return deciphered_text



if __name__ == "__main__":
   app = QApplication(sys.argv)
   ex = App()
   ex.show()
   sys.exit(app.exec())