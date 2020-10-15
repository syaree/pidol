import sys
from PyQt5.QtWidgets import (
    QApplication, QMainWindow,
    QLabel, QToolBar, QAction,
    QStatusBar, QCheckBox
)
from PyQt5.QtGui import QIcon
from PyQt5.QtCore import Qt, QSize


class MainWindow(QMainWindow):
    def __init__(self, *args, **kwargs):
        super(MainWindow, self).__init__(*args, **kwargs)

        self.setWindowTitle("PIDOL")
        self.setMinimumSize(400, 250)
        self.windowTitleChanged.connect(lambda x: print(x))

        label = QLabel()
        label.setText("Selamat Datang")
        label.setAlignment(Qt.AlignCenter)

        self.setCentralWidget(label)

        toolbar = QToolBar("Toolbar")
        toolbar.setIconSize(QSize(16, 16))
        toolbar.setContextMenuPolicy(Qt.PreventContextMenu)

        self.addToolBar(toolbar)

        btn_action = QAction(QIcon("asset/floppy.png"), "Aksi", self)
        btn_action.setStatusTip("Status Aksi")
        btn_action.setCheckable(True)
        btn_action.triggered.connect(lambda text: print("Triggered", text))
        toolbar.addAction(btn_action)

        toolbar.addSeparator()

        btn_action2 = QAction(QIcon("asset/floppy.png"), "Aksi 2", self)
        btn_action2.setStatusTip("Status Aksi 2")
        btn_action2.setCheckable(True)
        btn_action2.triggered.connect(lambda text: print("Triggered 2", text))
        toolbar.addAction(btn_action2)

        toolbar.addWidget(QLabel("Aktivasi"))
        toolbar.addWidget(QCheckBox())

        self.setStatusBar(QStatusBar(self))


if __name__ == "__main__":
    app = QApplication(sys.argv)

    window = MainWindow()
    window.show()

    sys.exit(app.exec_())
