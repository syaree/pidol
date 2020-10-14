import gi
gi.require_version("Gtk", "3.0")

from gi.repository import Gtk


class Handler:
    def onDestroy(self, _):
        Gtk.main_quit()

    def onButtonPressed(self, _):
        print("Clicked!")


if __name__ == "__main__":
    builder = Gtk.Builder()
    builder.add_from_file("ui.glade")
    builder.connect_signals(Handler())

    window = builder.get_object("window1")
    window.show_all()

    Gtk.main()
