from os import rename
from os import listdir

arquivos = listdir('.')
for arquivo in arquivos:
	rename(arquivo, arquivo.split('.')[0]+("_inv.")+arquivo.split('.')[1])

