#!/usr/bin/env python3
# -+- coding: utf-8 -+-

from flask import Flask, request, url_for
from json import dumps as json_dumps
import re


app = Flask(__name__)


STUDENTS = [{
    'uid': '17',
    'username': 'trit-s0002',
    'fullname': 'Ивановный Т. П.',
    'group': '11-T'
},{
    'uid': '16',
    'username': 'trit-s0003',
    'fullname': 'Ивановый И. П.',
    'group': '11-T'
},{
    'uid': '13',
    'username': 'trit-s0001',
    'fullname': 'Ивановок f. П.',
    'group': '11-T'
},{
    'uid': '12',
    'username': 'trit-s0002',
    'fullname': 'Петров В. И.',
    'group': '11-T'
},{
    'uid': '21',
    'username': 'trit-s0003',
    'fullname': 'Сидоров Х. Г.',
    'group': '12-T'
},{
    'uid': '22',
    'username': 'trit-s0004',
    'fullname': 'Ефанов М.А.',
    'group': '42-T'
}]
PASSWORDS = {
    'trit-s0001': 'abc',
    'trit-s0002': 'def',
    'trit-s0003': '112',
    'trit-s0004': 'ido'
}


NORMALIZE_RE = re.compile("\s{2,}")
def normalize_str(s):
    return NORMALIZE_RE.sub(' ', s, re.U|re.I).strip().lower()


@app.route('/api-v1/bootstrap.json')
def bootstrap():
    out = {
        'version': '1.0',
        'students_api_url': url_for('students', _external=True)
    }
    return json_dumps(out), 200, {'Content-Type': 'application/json'}


@app.route('/api-v1/students')
def students():
    query = normalize_str(request.values.get('q',''))
    out = []
    for student in STUDENTS:
        if query in normalize_str(student['username']): out.append(student)
        elif query in normalize_str(student['fullname']): out.append(student)

    return json_dumps(out), 200, {'Content-Type': 'application/json'}


@app.route('/api-v1/students/auth', methods=['POST'])
def auth():
    with open('log', 'a') as fp:
        fp.write('\r\n\r\n')
        for k, v in request.values.items():
            fp.write('{}={}\r\n'.format(k, v))

    username = request.values.get('username')
    password = request.values.get('password')
    if username in PASSWORDS and PASSWORDS[username] == password:
        return json_dumps({'s': True, 'authid': '11'}), 200, {'Content-Type': 'application/json'}

    return json_dumps({'s': False, 'e': 'Incorrect password'}), 200, {'Content-Type': 'application/json'}


@app.route('/api-v1/students/deauth', methods=['POST'])
def deauth():
    with open('log', 'a') as fp:
        fp.write('\r\n\r\n')
        for k, v in request.values.items():
            fp.write('{}={}\r\n'.format(k, v))

    return json_dumps({'s': True}), 200, {'Content-Type': 'application/json'}


if __name__ == '__main__':
    app.run('0.0.0.0')
