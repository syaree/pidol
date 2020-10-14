import sys
from PyQt5.QtWidgets import QApplication, QMainWindow, QLabel
from PyQt5.QtCore import Qt


class MainWindow(QMainWindow):
    def __init__(self, *args, **kwargs):
        super(MainWindow, self).__init__(*args, **kwargs)

        self.setWindowTitle("PIDOL")
        self.setMinimumSize(400, 250)

        label = QLabel()
        label.setText("Selamat Datang")
        label.setAlignment(Qt.AlignCenter)

        self.setCentralWidget(label)


if __name__ == "__main__":
    app = QApplication(sys.argv)

    window = MainWindow()
    window.show()

    sys.exit(app.exec_())
