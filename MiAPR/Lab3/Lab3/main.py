import sys
import numpy as np

from PyQt6 import uic
from PyQt6.QtWidgets import QApplication, QMainWindow, QMessageBox, QWidget, QVBoxLayout
from itertools import combinations

import matplotlib.pyplot as plt
import matplotlib
from matplotlib.figure import Figure

matplotlib.use('QtAgg')
from matplotlib.backends.backend_qt5agg import FigureCanvasQTAgg as FigureCanvas



class Canvas(FigureCanvas):
    def __init__(self, width=5, height=4, dpi=100):
        self.fig = Figure(figsize=(width, height), dpi=dpi)
        self.axes = self.fig.add_subplot(111)
        super().__init__(self.fig)

class Visualiser(QMainWindow):
    def __init__(self, data1, data2, decision_boundary, widget):
        super().__init__()
        canvas = Canvas()
        self.layout = QVBoxLayout()
        self.layout.addWidget(canvas)
        widget.setLayout(self.layout)
        x =data1[:,0]
        canvas.axes.cla()

        canvas.axes.plot(data1[:, 0], data1[:, 1])
        canvas.axes.plot(data2[:, 0], data2[:, 1])
        canvas.axes.axvline(decision_boundary, color="green", linestyle="--", label="Граница")
        canvas.axes.fill_between(data1[:, 0], 0, data1[:, 1], where=(x > decision_boundary), color="blue", alpha=0.2, label="Ложная тревога")
        canvas.axes.fill_between(data2[:, 0], 0, data2[:, 1], where=(x < decision_boundary), color="red", alpha=0.2,
                         label="Пропуск обнаружения")

        canvas.draw()









class GaussianClassifier:
    def __init__(self,P1, P2,widget, n_samples = 100):
        self.P1 = P1
        self.P2 = P2
        self.widget = widget

        self.X1 = np.random.normal(2, size=n_samples)
        self.X2 = np.random.normal(5, size=n_samples)

        self.x = np.linspace(-2, 10, 1000)

        mean1, mean2 = np.mean(self.X1), np.mean(self.X2)
        std1, std2 = np.std(self.X1), np.std(self.X2)

        self.p_x_C1 = self.find_density(self.x, mean1, std1)
        self.p_x_C2 = self.find_density(self.x, mean2, std2)

    def false_alarm(self):
        return np.trapezoid(self.p_x_C1[self.x > self.decision_boundary], self.x[self.x > self.decision_boundary])


    def miss_detection(self):
        return np.trapezoid(self.p_x_C2[self.x < self.decision_boundary], self.x[self.x < self.decision_boundary])

    def total_error(self):
        return self.false_alarm() + self.miss_detection()

    def find_density(self, x, mean, std):
        var1 = 1 / (std * np.sqrt(2 * np.pi))
        var2 = ((x - mean) ** 2) / (2 * std ** 2)
        proba = var1 * np.exp(-var2)
        return proba

    def calculate_posterior(self):
        P_x = self.p_x_C1 * self.P1 + self.p_x_C2 * self.P2
        self.P_C1_x = (self.p_x_C1 * self.P1) / P_x
        self.P_C2_x = (self.p_x_C2 * self.P2) / P_x
        self.decision_boundary = self.x[np.argmin(np.abs(self.P_C1_x - self.P_C2_x))]
        data1, data2 = np.column_stack((self.x, self.p_x_C1)), np.column_stack((self.x, self.p_x_C2))

        Visualiser(data1, data2, self.decision_boundary, self.widget)



def is_valid_number(textEdit, min_value, max_value):
    try:
        number = int(textEdit.toPlainText().strip())
        return min_value <= number <= max_value
    except ValueError:
        return False

class App(QMainWindow):
    def __init__(self):
        super().__init__()
        uic.loadUi('design.ui', self)

        self.calculateButton.clicked.connect(self.calculate)

    def get_proba(self, slider):
        return int(slider.value()) / 100

    def calculate(self):
        P1 = self.get_proba(self.proba1Slider)
        P2 = self.get_proba(self.proba2Slider)


        classifier = GaussianClassifier(P1, P2, self.widget)
        classifier.calculate_posterior()
        self.show_answers(classifier)

    def show_answers(self, classifier):
        answer = ""
        false_alarm = classifier.false_alarm()
        miss_detection = classifier.miss_detection()
        total_error = classifier.total_error()
        answer += f"False Alarm: {false_alarm :.4f}\n"
        answer += f"Miss Detection: {miss_detection:.4f}\n"
        answer += f"Total Error: {total_error:.4f}\n"
        self.answerLabel.setText(answer)


if __name__ == "__main__":
   app = QApplication(sys.argv)
   ex = App()
   ex.show()
   sys.exit(app.exec())
