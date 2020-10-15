import sys
from PyQt5.QtWidgets import (
    QApplication, QMainWindow,
    QLabel, QToolBar, QAction,
    QStatusBar, QCheckBox, QDialog,
    QDialogButtonBox, QVBoxLayout
)
from PyQt5.QtGui import QIcon
from PyQt5.QtCore import Qt, QSize


class CustomDialog(QDialog):
    def __init__(self, *args, **kwargs):
        super(CustomDialog, self).__init__(*args, **kwargs)

        self.setWindowTitle("Pemberitahuan")
        self.setMinimumSize(250, 180)

        qbtn = QDialogButtonBox.Ok | QDialogButtonBox.Cancel

        self.buttonBox = QDialogButtonBox(qbtn)
        self.buttonBox.accepted.connect(self.accept)
        self.buttonBox.rejected.connect(self.reject)

        self.layout = QVBoxLayout()
        self.layout.addWidget(self.buttonBox)
        self.setLayout(self.layout)


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
        btn_action.triggered.connect(self.on_button_action_clicked)
        toolbar.addAction(btn_action)

        toolbar.addSeparator()

        btn_action2 = QAction(QIcon("asset/floppy.png"), "Aksi 2", self)
        btn_action2.setStatusTip("Status Aksi 2")
        btn_action2.setCheckable(True)
        btn_action2.triggered.connect(self.on_button_action_clicked)
        toolbar.addAction(btn_action2)

        toolbar.addWidget(QLabel("Aktivasi"))
        toolbar.addWidget(QCheckBox())

        self.setStatusBar(QStatusBar(self))

    def on_button_action_clicked(self, s):
        print("Click", s)

        dlg = CustomDialog(self)
        dlg.exec_()


if __name__ == "__main__":
    app = QApplication(sys.argv)

    window = MainWindow()
    window.show()

    sys.exit(app.exec_())
