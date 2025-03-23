import sys


from PyQt6 import uic
from PyQt6.QtWidgets import QApplication, QMainWindow, QMessageBox, QWidget, QVBoxLayout
import numpy as np
import matplotlib
matplotlib.use('QtAgg')
from matplotlib.backends.backend_qt5agg import FigureCanvasQTAgg as FigureCanvas
from matplotlib.figure import Figure



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


#высчитываю новую центроиду
def update_cores(X, K, labels):
    new_cores = np.zeros((K, 2))
    for i in range(K):
        count = 0
        sum_x, sum_y = 0, 0
        for j in range(len(X)):
            if labels[j] == i:
                sum_x += X[j][0]
                sum_y += X[j][1]
                count += 1
        if count > 0:
            new_cores[i] = (sum_x / count, sum_y / count)
        else:
            new_cores[i] = np.random.randint(0, 100_000, size= 2)  # Новый случайный центр
    return new_cores


class Canvas(FigureCanvas):
    def __init__(self):
        self.fig = Figure()
        self.axes = self.fig.add_subplot(111)
        super().__init__(self.fig)




class KMeansVisualisation(QMainWindow):
    def __init__(self, n_samples, n_clusters, widget: QWidget, n_iterations = 10 ):
        super().__init__()
        X = np.random.randint(0, 100_000, size=(n_samples, 2))
        cores = np.random.randint(0, 100_000, size=(n_clusters, 2))
        classes = np.zeros(len(X))

        canvas = Canvas()
        layout = QVBoxLayout()
        layout.addWidget(canvas)
        widget.setLayout(layout)

        for i in range(10):
            classes = class_list(X, cores)
            cores = update_cores(X, n_clusters, classes)

        canvas.axes.scatter(X[:, 0], X[:, 1], c=classes, cmap="viridis", alpha=0.7, s=5, label="Образы")
        canvas.axes.scatter(cores[:, 0], cores[:, 1], color="red", marker="*", s=200, label="Центроиды")






class App(QMainWindow):
    def __init__(self):
        super().__init__()
        uic.loadUi('lab1.ui', self)

        self.calculateBtn.setEnabled(False)
        self.NEdit.textChanged.connect(self.validate_input)
        self.calculateBtn.clicked.connect(self.calculate_clicked)

    def validate_input(self):
        k_valid = self.is_valid_number(self.KEdit, 2, 20)
        n_valid = self.is_valid_number(self.NEdit, 1000, 10_000)
        self.calculateBtn.setEnabled(k_valid and n_valid)

    def is_valid_number(self, textEdit, min_value, max_value):
        try:
            number = int(textEdit.toPlainText().strip())
            return min_value <= number <= max_value
        except ValueError:
            return False
    def calculate_clicked(self):
        n_clusters = int(self.KEdit.toPlainText().strip())
        n_samples = int(self.NEdit.toPlainText().strip())
        KMeansVisualisation(n_samples, n_clusters, self.widget)



if __name__ == "__main__":
   app = QApplication(sys.argv)
   ex = App()
   ex.show()
   sys.exit(app.exec())



