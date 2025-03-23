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


def euclidean_distance(x1, x2):
    return np.sqrt(np.sum((x1 - x2) ** 2))


#каждой точке определяю новый класс по центроиде
def class_list(X, cores):
    new_classes = np.zeros(len(X))
    for i in range(len(X)):
        min_dist = 100000
        for j in range(len(cores)):
            dist = euclidean_distance(X[i], cores[j])
            if dist < min_dist:
                min_dist = dist
                new_classes[i] = j
    return new_classes


def find_max_index(X, n):
    max_distance = 0
    max_index = 0
    for i in range(len(X)):
        dist = euclidean_distance(X[i], n)
        if dist > max_distance:
            max_distance = dist
            max_index = i
    return max_index

def find_max_distances(X, cores, classes):
    max_distances = np.zeros(len(cores))
    max_indexes = np.zeros(len(cores), dtype = int)
    for i in range(len(cores)):
        for j in range(len(X)):
            if classes[j] == i:
                distance = euclidean_distance(X[j], cores[i])
                if distance > max_distances[i]:
                    max_distances[i] = distance
                    max_indexes[i] = j
    return max_distances, max_indexes


def mean_core_distance(cores):
    """Считает среднее арифметическое расстояний между всеми ядрами."""
    distances = [np.linalg.norm(np.array(c1) - np.array(c2)) for c1, c2 in combinations(cores, 2)]
    return np.mean(distances)


def max_algorithm(n_samples, widget):
    X = np.random.randint(0, 100_000, size=(n_samples, 2))
    cores = []
    classes = np.zeros(len(X))

    n1 = X[np.random.randint(0, len(X))]
    cores.append(n1)
    n2 = X[find_max_index(X, n1)]
    cores.append(n2)
    print(X)
    print(cores)


    can_add_new = True
    while can_add_new:
        classes = class_list(X, cores)
        max_distances, max_indexes = find_max_distances(X, cores, classes)
        mean_distance = mean_core_distance(cores)
        if max(max_distances) > mean_distance / 2:   #самая большое расстояние больше чем половина между всеми ядрами
            index = np.argmax(max_distances)
            core = X[max_indexes[index]]
            cores.append(core)
            print(f"cores length: {len(cores)}")
            print(f"cores: {cores}")
        else:
            can_add_new = False
    Visualiser(X, np.array(cores), classes, widget)

class Canvas(FigureCanvas):
    def __init__(self, width=5, height=4, dpi=100):
        self.fig = Figure(figsize=(width, height), dpi=dpi)
        self.axes = self.fig.add_subplot(111)
        super().__init__(self.fig)



class Visualiser(QMainWindow):
    def __init__(self, X, cores,classes, widget):
        super().__init__()
        canvas = Canvas()
        canvas.axes.scatter(X[:, 0], X[:, 1], c=classes, cmap="viridis", alpha=0.7, s=5, label="Образы")
        canvas.axes.scatter(cores[:, 0], cores[:, 1], s=150, c='r', marker='*')
        self.layout = QVBoxLayout()
        self.layout.addWidget(canvas)
        widget.setLayout(self.layout)
        self.show()



class App(QMainWindow):
    def __init__(self):
        super().__init__()
        uic.loadUi('lab2.ui', self)
        self.calculateButton.setEnabled(False)
        self.NEdit.textChanged.connect(self.validate_input)
        self.calculateButton.clicked.connect(self.calculate)

        self.canvas = Canvas()


    def validate_input(self):
        n_valid = self.is_valid_number(self.NEdit, 1000, 10_000)
        self.calculateButton.setEnabled( n_valid)

    def is_valid_number(self, textEdit, min_value, max_value):
        try:
            number = int(textEdit.toPlainText().strip())
            return min_value <= number <= max_value
        except ValueError:
            return False

    def calculate(self):
        n_samples = int(self.NEdit.toPlainText())

        X = np.random.randint(0, 100_000, size=(n_samples, 2))
        cores = []
        classes = np.zeros(len(X))

        n1 = X[np.random.randint(0, len(X))]
        cores.append(n1)
        n2 = X[find_max_index(X, n1)]
        cores.append(n2)
        print(X)
        print(cores)
        max_algorithm(n_samples, self.widget)
'''
        self.canvas.axes.scatter(X[:, 0], X[:, 1], c=classes, cmap="viridis", alpha=0.7, s=5, label="Образы")
        self.canvas.axes.scatter(cores[:, 0], cores[:, 1], s=150, c='r', marker='*')
        layout = QVBoxLayout()
        layout.addWidget(self.canvas)# а какого хуя
        self.widget.setLayout(layout)
'''



if __name__ == "__main__":
   app = QApplication(sys.argv)
   ex = App()
   ex.show()
   sys.exit(app.exec())

