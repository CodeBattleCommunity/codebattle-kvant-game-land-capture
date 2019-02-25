#!/usr/bin/env python
# -*- coding:utf-8 -*-
import requests
import sys
from PyQt5.QtCore import Qt, QAbstractTableModel, QModelIndex, QSortFilterProxyModel
from PyQt5.QtGui import QPixmap, QFont
from PyQt5.QtWidgets import QApplication, QDesktopWidget, QPushButton, QLabel, QLineEdit, QComboBox, \
    QWidget, QSystemTrayIcon, QStyle, QDialog, QVBoxLayout, QTableView, \
    QAbstractItemView, QCompleter

addserv = 'http://127.0.0.1:5000'


class Model(QAbstractTableModel):
    def __init__(self):
        QAbstractTableModel.__init__(self)
        self.ls = []
        self._search_term = ''

    def setSearchTerm(self, term):
        self.layoutAboutToBeChanged.emit()
        self._search_term = term or ''
        if len(self._search_term) == 4:
            r = requests.get(
                '{}/api-v1/students'.format(addserv),
                params={
                    'q': self._search_term
                }
            )
            self.ls = r.json()
        self.layoutChanged.emit()

    def rowCount(self, parent=QModelIndex(), *args, **kwargs):
        return len(self.ls)

    def columnCount(self, index=QModelIndex(), *args, **kwargs):
        return 3

    def data(self, index, role=None):
        if not index.isValid() or (role not in [Qt.DisplayRole, Qt.EditRole]):
            return None

        row = index.row()
        column = index.column()

        if column == 0:
            if not len(self.ls): return None
            item = self.ls[row]
            return item['fullname']

        elif column == 1:
            if not len(self.ls): return None
            item = self.ls[row]
            return item['group']

        elif column == 2:
            if not len(self.ls): return None
            item = self.ls[row]
            return item['username']
        else:
            return None


class ErrorDialog(QDialog):
    def __init__(self, parent=None):
        super().__init__(parent=parent)
        self.setModal(True)
        self.setWindowFlags(Qt.Window | Qt.WindowCloseButtonHint | Qt.CustomizeWindowHint)
        self.setFont(QFont("Serif", 12, QFont.Bold))
        self.setWindowIcon(self.style().standardIcon(QStyle.SP_BrowserStop))
        box = QVBoxLayout()

        self.buttonyes = button1 = QPushButton('Да')
        self.buttonno = button2 = QPushButton('Нет')
        self.buttonyes.clicked.connect(self.yesButtonClick)
        self.buttonno.clicked.connect(self.noButtonClick)
        self.buttonyes.hide()
        self.buttonno.hide()

        self.textLabel = lbl = QLabel()
        box.addWidget(lbl)
        box.addWidget(button2)
        box.addWidget(button1)
        self.setLayout(box)

    def yesButtonClick(self):
        self.parent().show()
        self.hide()

    def noButtonClick(self):
        self.hide()

    def keyPressEvent(self, event):
        if event.key() == Qt.Key_Return:
            self.hide()
        elif event.key() == Qt.Key_Escape:
            self.hide()

    def closeEvent(self, event):
        event.ignore()
        self.hide()

    def setText(self, text):
        self.textLabel.setText(text)

    def setTitle(self, text):
        self.setWindowTitle(text)

    def addYesAndNot(self):
        self.buttonyes.show()
        self.buttonno.show()

    @classmethod
    def showError(cls, parent, message, title, buttonOn):
        dlg = cls(parent)

        if message is not None: dlg.setText(message)
        if title is not None: dlg.setTitle(title)
        if buttonOn: dlg.addYesAndNot()

        dlg.show()
        return dlg.exec_()


class ComboBox(QComboBox):
    def __init__(self, parent=None):
        super(ComboBox, self).__init__(parent)
        tablev = QTableView()
        tablev.horizontalHeader().hide()
        tablev.verticalHeader().hide()
        tablev.setSelectionBehavior(QAbstractItemView.SelectRows)
        self.setFont(QFont("Times New Roman", 12, QFont.Bold))
        self.setView(tablev)
        self.setFocusPolicy(Qt.StrongFocus)
        self.setEditable(True)
        self.usernameComboModel = Model()
        self.pFilterModel = QSortFilterProxyModel(self)
        self.pFilterModel.setFilterCaseSensitivity(Qt.CaseInsensitive)
        self.pFilterModel.setSourceModel(self.usernameComboModel)

        self.completer = QCompleter(self.pFilterModel, self)
        self.completer.setCompletionMode(QCompleter.UnfilteredPopupCompletion)
        self.setCompleter(self.completer)
        self.setModel(self.usernameComboModel)
        self.lineEdit().textEdited.connect(self.pFilterModel.setFilterFixedString)
        self.completer.activated.connect(self.on_completer_activated)
        self.editTextChanged.connect(self.changeColumn)

    def on_completer_activated(self, text):
        if text:
            index = self.findText(text)
            self.setCurrentIndex(index)
            self.activated[str].emit(self.itemText(index))

    def setModel(self, model):
        super(ComboBox, self).setModel(model)
        self.pFilterModel.setSourceModel(model)
        self.completer.setModel(self.pFilterModel)

    def changeColumn(self):
        self.usernameComboModel.setSearchTerm(self.currentText())
        if len(self.currentText()) == 4:
            fullname = []
            username = []
            for i in self.usernameComboModel.ls:
                fullname.append(i['fullname'])
                username.append(i['username'])
            ustr = ''
            fstr = ''
            for i in fullname:
                S = str(self.currentText()[:1]).upper() + self.currentText()[1:]
                if S in i:
                    fstr = i
            for i1 in username:
                if self.currentText() in i1:
                    ustr = i1
            if ustr:
                if self.modelColumn() == 0:
                    self.setModelColumn(2)
                    self.setCurrentText(ustr)
            elif fstr:
                if self.modelColumn() == 2:
                    self.setModelColumn(0)
                    self.setCurrentText(S)
                else:
                    pass

    def setModelColumn(self, column):
        self.completer.setCompletionColumn(column)
        self.pFilterModel.setFilterKeyColumn(column)
        super(ComboBox, self).setModelColumn(column)


class MainWindow(QWidget):
    def __init__(self):
        super().__init__()
        self.authStatus = False
        self.usernameComboModel = Model()

        self.usernameCombo = ComboBox(self)
        self.passwordEdit = QLineEdit(self)
        self.tray_icon = QSystemTrayIcon(self)
        self.qpb = QPushButton('Войти в систему!', self)

        self.lbl_stud = QLabel(self)
        self.lbl_pass = QLabel(self)
        self.lbl_pix = QLabel(self)
        self.lbl_exp = QLabel(self)

        self.lbl_pix.setPixmap(QPixmap("logo.png"))
        self.initUI()

    def initUI(self):
        # move
        q = QDesktopWidget().availableGeometry()
        x = q.width() / 2
        y = q.height() / 2
        y_element = 30
        x_element = 302
        # Edit
        self.lbl_exp.setText('Для продолжения работы введите ваше ФИО и пароль от электронного журнала')
        self.lbl_stud.setText("Имя студента")
        self.lbl_pass.setText('Пароль')
        # x/y
        self.lbl_exp.move(x - 600, y - 100)
        self.lbl_pass.move(x - (x_element / 2), y + 35)
        self.passwordEdit.move(x - (x_element / 2), y + 61)
        self.lbl_stud.move(x - (x_element / 2), y - 27)
        self.qpb.move(x - 50, y + 100)
        self.usernameCombo.move(x - (x_element / 2), y)
        self.lbl_pix.move(100, 100)

        self.passwordEdit.resize(x_element, y_element)
        self.usernameCombo.resize(x_element, y_element)
        # params
        self.passwordEdit.setEchoMode(QLineEdit.Password)
        self.lbl_stud.setFont(QFont("Serif", 12, QFont.Bold))
        self.lbl_pass.setFont(QFont("Serif", 12, QFont.Bold))
        self.lbl_exp.setFont(QFont("Serif", 20, QFont.Bold))
        # tray
        self.tray_icon.setIcon(self.style().standardIcon(QStyle.SP_ComputerIcon))
        # connect
        self.tray_icon.activated.connect(self.systemTrayIcon)
        self.qpb.clicked.connect(self.buttonClicked)
        # end
        self.showFullScreen()
        self.checkInternet()

    def systemTrayIcon(self, reason):
        if reason == QSystemTrayIcon.DoubleClick:
            if self.authStatus:
                ErrorDialog.showError(self, 'Вы точно хотите переавторизоваться?', 'Переавторизация', True)
            elif not self.authStatus:
                ErrorDialog.showError(self, 'Вы точно хотите авторизоваться?', 'Авторизация', True)

    def closeEvent(self, event):
        event.ignore()
        self.hide()
        self.usernameCombo.setCurrentText('')
        self.passwordEdit.setText('')
        self.tray_icon.show()
        self.tray_icon.showMessage('Я ещё здесь!', 'Если захотите авторизоваться - щёлкните на этот значок')

    def showErr(self):
        ErrorDialog.showError(self, "Введите логин и пароль корректно!", 'Уведомление об ошибке!', False)

    def showCritErr(self):
        ErrorDialog.showError(self,
                              "Ошибка соединения!\nОбратитесь к системному администратору.\nF5 чтобы повторить попытку.",
                              'Уведомление об ошибке!', False)

    def checkInternet(self):
        try:
            r = requests.get('{}/api-v1/students'.format(addserv))
        except:
            self.showCritErr()

    def clickButton(self):
        check = (
            str(self.usernameCombo.currentText()).isspace(),
            str(self.passwordEdit.text()).isspace(),
            str(self.usernameCombo.currentText()) == '',
            str(self.passwordEdit.text()) == ''
        )
        if any(check):
            self.showErr()
            return 1

        idx = self.usernameCombo.currentIndex()
        username = self.usernameComboModel.data(
            self.usernameComboModel.index(idx, 2),
            Qt.DisplayRole
        )
        fullname = self.usernameComboModel.data(
            self.usernameComboModel.index(idx, 0),
            Qt.DisplayRole
        )
        try:
            rsp = requests.post(
                '{}/api-v1/students/auth'.format(addserv),
                data={
                    'username': username,
                    'password': self.passwordEdit.text()
                }
            )
            rsp_json = rsp.json()

        except:
            self.showCritErr()
            return 1

        if rsp_json['s']:
            self.hide()
            self.authStatus = True
            self.tray_icon.show()
            self.tray_icon.showMessage('Добро пожаловать! {}'.format(fullname),
                                       'Авторизация успешна. Чтобы переавторизоваться нажмите на меня')
            self.usernameCombo.setCurrentText('')
            self.passwordEdit.setText('')
        else:
            self.showErr()
            return 1

    def keyPressEvent(self, e):
        if e.key() == Qt.Key_F7:
            exit()

        elif e.key() == Qt.Key_Return:
            self.clickButton()

        elif e.key() == Qt.Key_F5:
            self.checkInternet()

    def buttonClicked(self):
        self.clickButton()


if __name__ == '__main__':
    app = QApplication(sys.argv)

    ex = MainWindow()
    sys.exit(app.exec_())
