import hashlib
import time
import sys


class Bloque:
    def __init__(self):
        self.nombre_bloque = ""
        self.id = 0
        self.hora = time.strftime("%H:%M:%S")
        self.datos = ""
        self.hash_anterior=0
        self.siguiente=""
        self.hash = ""
    def hash_bloque(self):
        sha=(str(self.id) + str(self.hora) + str(self.datos) + str(self.hash_anterior))
        return (hashlib.sha256(sha.encode()).hexdigest())


class Intercambio:
    bloques = []
    continuar = False
    while not continuar:
        bloque = Bloque()
        hora = time.strftime("%H:%M:%S")
        data=input("Ingrese Datos :")
        bloque.nombre_bloque ="Inkadroid"
        if(bloques.__len__() == 0):
            bloque.id = bloque.id+1
            bloque.hash_anterior = bloque.hash_anterior
        else:
            temp = bloques[bloques.__len__() - 1]
            bloque.id =temp.id+1
            bloque.hash_anterior = temp.siguiente
        bloque.hora = hora
        bloque.datos = data
        bloque.siguiente = bloque.hash_bloque()
        bloque.hash = bloque.siguiente
        bloques.append(bloque)
        letra = input('Desea agregar más bloques S/N: ')
        if(letra == 'S'):
            continuar = False
        else:
            continuar = True
    for bloque in bloques:
        print("------------------------------")
        print("Bloque :",bloque.nombre_bloque)
        print("Id Bloque :",bloque.id)
        print("Transaccion :",bloque.hora)
        print("Data :",bloque.datos)
        print("hash anterior :",bloque.hash_anterior)
        print("bloque.siguiente",bloque.siguiente)
        print("hash",bloque.hash)
if __name__ == '__main__':
    intercambio = Intercambio()