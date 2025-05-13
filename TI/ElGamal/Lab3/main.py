import sys
import random
import math
import re
from PyQt6 import uic
from PyQt6.QtWidgets import QApplication, QMainWindow, QMessageBox, QWidget, QVBoxLayout, QFileDialog, QTextEdit, QPushButton


class ElGamalCore():
    def __init__(self, p, x, k):
        self.p = p
        self.x = x  # закрытый ключ
        self.k = k  # случайный секрет  # открытый ключ y = g^x mod p

        #self.y = pow(self.g, self.x, self.p)



    def is_prime(self, n, k = 10):
        if n <= 1 or n == 4:
            return False
        if n <= 3:
            return True
        for _ in range(k):
            a = random.randint(2, n - 2)
            if pow(a, n - 1, n) != 1:
                return False
        return True

    def is_primitive_root(self, g, p):
        phi = p - 1
        factors = set()
        n = phi
        i = 2
        while i * i <= n:
            while n % i == 0:
                factors.add(i)
                n //= i
            i += 1
        if n > 1:
            factors.add(n)
        for q in factors:
            if pow(g, phi // q, p) == 1:
                return False
        return True

    def find_primitive_roots(self, p=None):
        if p is None:
            p = self.p

        roots = []
        for g in range(2, p):
            if self.is_primitive_root(g, p):
                roots.append(g)
        return roots

    def check_coprime(self):
        k = self.k
        p = self.p
        if math.gcd(k, p - 1) != 1:
            return False
        return True


class ElGamalCipher:
    def __init__(self, p, x, k, g):
        self.p = p
        self.x = x  # закрытый ключ
        self.k = k  # случайный секрет
        self.g = g  # первообразный корень
        self.y = pow(g, x, p)


    def encrypt(self, message):
        encrypted_message = []
        numbers = [int(num) for num in message.split()]

        # Для каждого символа в сообщении
        for m in numbers:
            #m = ord(char)  #Получаем ASCII код символ

            # Шифруем:
            a = pow(self.g, self.k, self.p)  # a = g^k mod p
            b = pow(self.y, self.k, self.p) * m % self.p  # b = y^k * m mod p

            encrypted_message.append((a, b))  #Добавляем пару (a, b) в шифротекст

        return encrypted_message

    def parse_encrypted_string(self, encrypted_str):
        # Находит все подстроки вида (a, b)
        pairs = re.findall(r'\((\d+),\s*(\d+)\)', encrypted_str)
        # Преобразует в список кортежей с числами
        return [(int(a), int(b)) for a, b in pairs]

    def decrypt(self, encrypted_message_str):
        decrypted_message = []
        encrypted_message = self.parse_encrypted_string(encrypted_message_str)

        # Расшифровка
        for a, b in encrypted_message:
            # Вычисляем s = a^x mod p
            s = pow(a, self.x, self.p)

            # Вычисляем s^(-1) mod p — обратный элемент
            s_inv = pow(s, -1, self.p)

            # Расшифровываем символ: M = b * s^(-1) mod p
            m = (b * s_inv) % self.p

            decrypted_message.append(m)
        return decrypted_message




class App(QMainWindow):
    def __init__(self):
        super().__init__()
        uic.loadUi('design.ui', self)
        self.p = 0
        self.x = 0
        self.k = 0

        self.encypherButton.setEnabled(not self.are_edits_empty(self.PEdit, self.KEdit, self.XEdit))


        self.PEdit.textChanged.connect(self.check_encipher_edits)
        self.KEdit.textChanged.connect(self.check_encipher_edits)
        self.XEdit.textChanged.connect(self.check_encipher_edits)
        self.openAction.triggered.connect(self.open_file)
        self.saveAction.triggered.connect(self.save_file)
        self.saveCipherAction.triggered.connect(self.save_cipher)
        self.openCipherAction.triggered.connect(self.open_cipher)

        self.findGButton.clicked.connect(self.load_primitive_roots)
        self.encypherButton.clicked.connect(self.encipher_button_click)
        self.decypherButton.clicked.connect(self.decipher_button_click)

    def check_numb(self, numb, min_val, max_val):
        try:
            # Преобразуем в целое число
            numb = int(numb)
        except ValueError:
            # Если не удаётся преобразовать в int
            return False, "Значение должно быть целым числом."

        # Проверяем, что число в пределах диапазона
        if numb < min_val or numb > max_val:
            return False, f"Значение должно быть в пределах от {min_val} до {max_val}."

        return True, ""  # Если всё ок

    def show_error(self, error_message):
        QMessageBox.critical(self, "Ошибка", error_message)


    def load_primitive_roots(self):
        p = re.sub(r'\D', '', self.PEdit.toPlainText())  # Удаляем всё, что не цифра
        x = re.sub(r'\D', '', self.XEdit.toPlainText())
        k = re.sub(r'\D', '', self.KEdit.toPlainText())

        self.PEdit.setPlainText(p)
        self.XEdit.setPlainText(x)
        self.KEdit.setPlainText(k)

        # Проверяем значения p, x и k
        valid, error_message = self.check_numb(p, 2, 1000000)  # от 2 до 10000 для p
        if not valid:
            self.show_error(error_message)
            return

        valid, error_message = self.check_numb(x, 1, int(p) - 1)  # x должно быть в пределах от 1 до p-1
        if not valid:
            self.show_error(error_message)
            return

        valid, error_message = self.check_numb(k, 1, int(p) - 1)  # k должно быть в пределах от 1 до p-1
        if not valid:
            self.show_error(error_message)
            return

        # Если все значения прошли проверку, продолжаем
        self.p = int(p)
        self.x = int(x)
        self.k = int(k)
        self.elgamalCore = ElGamalCore(self.p, self.x, self.k)
        if not self.elgamalCore.is_prime(self.p):
            self.show_error("Введённое число p не является простым!")
            return

        if not self.elgamalCore.check_coprime():
            self.show_error("k и p-1 должны быть взаимно простыми.")
            return


        primitive_roots = self.elgamalCore.find_primitive_roots(self.p)
        self.gComboBox.clear()
        for root in primitive_roots:
            self.gComboBox.addItem(str(root))

    def check_combobox_selection(self):
        selected_item = self.gComboBox.currentText()  # Получаем текст выбранного элемента
        if not selected_item:  # Если выбранный элемент пустой
            self.show_error("Выберите первообразный корень из списка.")
            return False
        return True

    def encipher_button_click(self):
        p = self.p
        x = self.x
        k = self.k
        if not self.check_combobox_selection():  # Проверяем перед выполнением действия
            self.show_error("Выберите первообразный корень из списка.")
            return

        message = self.plainTextEdit.toPlainText()
        g = int(self.gComboBox.currentText())
        cipher = ElGamalCipher(p, x, k , g)
        encrypted_message = cipher.encrypt(message)
        encrypted_message_str = ' '.join([f"({a}, {b})" for a, b in encrypted_message])

        # Устанавливаем текст в resultEdit
        self.resultEdit.setText(encrypted_message_str)



    def decipher_button_click(self):
        p = self.p
        x = self.x
        k = self.k
        if not self.check_combobox_selection():  # Проверяем перед выполнением действия
            return


        ciphertext = self.plainTextEdit.toPlainText()


        g = int(self.gComboBox.currentText())
        cipher = ElGamalCipher(p, x, k, g)
        decrypted_message = cipher.decrypt(ciphertext)
        self.resultEdit.setText(str(decrypted_message))




    def check_encipher_edits(self):
        self.encypherButton.setEnabled(not self.are_edits_empty(self.PEdit, self.KEdit, self.XEdit))

    def check_decipher_edits(self):
        pass


    def are_edits_empty(self, edit1, edit2, edit3):
        if edit1.toPlainText() == "" or edit2.toPlainText() == "" or edit3.toPlainText() == "" or self.plainTextEdit.toPlainText() == "":
            return True

    def open_file(self):
        file_name, _ = QFileDialog.getOpenFileName(
            self, "Выберите файл", "", "Все файлы (*.*)"
        )
        try:
            with open(file_name, "rb") as file:
                result = []
                byte = file.read(1)
                while byte:
                    result.append(str(int.from_bytes(byte, byteorder='big')))
                    byte = file.read(1)
                self.plainTextEdit.setPlainText(" ".join(result))
        except Exception as e:
            self.show_error(f"Ошибка при чтении файла: {e}")

    def open_cipher(self):
        file_name, _ = QFileDialog.getOpenFileName(
            self, "Выберите файл", "", "Все файлы (*.*)"
        )
        try:
            with open(file_name, "r") as file:
                cipher = file.read()
                self.plainTextEdit.setPlainText(cipher)
        except Exception as e:
            self.show_error(f"Ошибка при чтении файла: {e}")




    def save_file(self):
        file_name, _ = QFileDialog.getOpenFileName(
            self, "Выберите файл"
        )
        numbers = self.resultEdit.toPlainText()
        if file_name:
            # Получаем строку чисел из QTextEdit
            numbers_str = self.resultEdit.toPlainText()


            # Преобразуем строку в список чисел
            numbers_str = numbers_str.strip('[]')
            # Преобразуем строку в список чисел, разделяя по запятой
            numbers = list(map(int, numbers_str.split(', ')))

            characters = []
            for num in numbers:
                characters.append(chr(num))

            try:
                byte_data = bytes(numbers)
            except ValueError as e:
                self.show_error(f"Ошибка: одно из чисел не в диапазоне 0-255\n{e}")
                return

            with open(file_name, "wb") as file:
                file.write(byte_data)

    def save_cipher(self):
        file_name, _ = QFileDialog.getSaveFileName(self, "Сохранить файл")
        if file_name:
            # Получаем строку чисел из QTextEdit
            result = self.resultEdit.toPlainText()

            if not result:
                self.show_error("Ошибка: поле результата пустое.")
                return

            try:
                with open(file_name, "w", encoding="utf-8") as file:
                    # Сохраняем как строку чисел, разделённых запятой
                    file.write(result)
            except Exception as e:
                self.show_error(f"Ошибка при сохранении файла:\n{e}")


if __name__ == "__main__":
   app = QApplication(sys.argv)
   ex = App()
   ex.show()
   sys.exit(app.exec())