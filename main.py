import gi

gi.require_version("Gtk", "3.0")


if __name__ == "__main__":
    from gi.repository import Gtk

    window = Gtk.Window(title="Coba GTK")
    window.show()

    window.connect("destroy", Gtk.main_quit)
    Gtk.main()
