from Window import Window as window
import tkinter as tk


root = tk.Tk()
app = window(root)
app.pack()
root.title("Cubic Spline")
root.geometry("640x480")
root.resizable(False, False)
root.mainloop()
    