import requests
import random
import time

address = ['map','player','reg']
for i in address:
    try:
        r = requests.post('http://localhost:5000/api-v1/{}'.format(i), data={"id":random.randrange(1,50)})
        print(i + ': ' + r.json())
        time.sleep(1)
    except:
        print(i + ': post except')

    try:
        r = requests.get('http://localhost:5000/api-v1/{}/12'.format(i))
        print(i + ': ' + r.json())
        time.sleep(1)
    except:
        print(i + ': get except')

    try:
        r = requests.put('http://localhost:5000/api-v1/{}/12'.format(i), data={"id":12})
        print(i + ': ' + r.json())
        time.sleep(1)
    except:
        print(i + ': put except')
