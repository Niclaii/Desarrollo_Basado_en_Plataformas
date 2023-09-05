#Escribir un programa que obtenga el numero mayor de n números ingresados por el usuario

lista = [0]
Sigue = True
i = 0

while Sigue == True:
    n=int(input("Ingrese el numero que desea: "))

    lista.append(n)

    i+=1

    if n == 0:
        Sigue = False
cont = 0
while Sigue == False:
    if cont < lista[i]:
        cont = lista[i]





print (cont)
