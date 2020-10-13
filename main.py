import gi

gi.require_version("Gtk", "3.0")
from gi.repository import Gtk


class App(Gtk.Window):
    def __init__(self):
        Gtk.Window.__init__(self, title="Coba GTK")

        self.button = Gtk.Button(label="Click Here")
        self.button.connect("clicked", self.on_btn_click)

        self.add(self.button)

    def on_btn_click(self, widget):
        print("Uji coba menggunakan GTK")


if __name__ == "__main__":
    window = App()
    window.connect("destroy", Gtk.main_quit)
    window.show_all()

    Gtk.main()
