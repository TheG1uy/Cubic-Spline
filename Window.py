import tkinter as tk

class Window(tk.Frame):
    def __init__(self, root):
        super().__init__(root)
        self.init_window(root)

    def init_window(self, root):
        C = Canvas(root, bg="blue", height=250, width=300)
        filename = PhotoImage(file = 'bg1.png')
        background_label = Label(top, image=filename)
        background_label.place(x=0, y=0, relwidth=1, relheight=1)
        C.pack()