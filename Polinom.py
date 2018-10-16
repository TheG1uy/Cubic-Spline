class Polinom(object):
    """description of class"""
    def __init__(self, a= 0, b = 0, c = 0, d = 0, x = 0):
        self.a = a
        self.b = b
        self.c = c
        self.d = d
        self.x = x

    def calcul(self, value) :
        return self.a + self.b * (value - x)  + self.c * (value - x) ** 2 + self.d * (value - x) ** 3