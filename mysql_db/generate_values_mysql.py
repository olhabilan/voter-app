import string, random, time
from random import randint
END = input("Please enter count of raws:") or 1
for i in range(0, int(END)):
    print ('(\"'+''.join(random.choices(string.ascii_uppercase + string.ascii_lowercase + string.digits, k=8))+'\", '+str(randint(1, 6)) +', \"'+ time.strftime('%Y-%m-%d %H:%M:%S') +'\"),'  )