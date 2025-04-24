import shutil

from flask import Flask, request, jsonify, send_file, Response
import os
from datetime import datetime

app = Flask(__name__)

STORAGE_DIR = './storage'

os.makedirs(STORAGE_DIR, exist_ok=True)

def get_full_path(path):
    return os.path.join(STORAGE_DIR, path)

@app.route('/<path:file_path>', methods=['PUT'])
def upload_file(file_path):
    full_path = get_full_path(file_path)
    os.makedirs(os.path.dirname(full_path), exist_ok=True)  # Создаём директории, если их нет

    with open(full_path, 'wb') as f:
        f.write(request.data)

    return jsonify({'message': f'Файл {file_path} успешно загружен'}), 201

@app.route('/<path:file_path>', methods=['HEAD'])
def get_file_info(file_path):
    full_path = get_full_path(file_path)
    if os.path.isfile(full_path):
        file_stats = os.stat(full_path)
        headers = {
            'Content-Length': file_stats.st_size,
            'Last-Modified': datetime.fromtimestamp(file_stats.st_mtime).strftime('%a, %d %b %Y %H:%M:%S GMT')
        }
        print(headers)
        return Response(headers), 200
    else:
        return jsonify({'error': f'Файл {file_path} не найден'}), 404

@app.route('/<path:file_path>', methods=['GET'])
@app.route('/', methods=['GET'])
def get_file_or_directory(file_path=None):
    full_path = STORAGE_DIR if file_path is None else get_full_path(file_path)
    if os.path.isfile(full_path):
        return send_file(full_path)
    elif os.path.isdir(full_path):
        files = os.listdir(full_path)
        return jsonify({'files': files})
    else:
        return jsonify({'error': f'Файл или директория {file_path} не найдены'}), 404

@app.route('/<path:file_path>', methods=['DELETE'])
def delete_file_or_directory(file_path):
    full_path = get_full_path(file_path)
    if os.path.isfile(full_path):
        os.remove(full_path)
        return jsonify({'message': f'Файл {file_path} успешно удалён'}), 200
    elif os.path.isdir(full_path):
        shutil.rmtree(full_path)
        return jsonify({'message': f'Каталог {file_path} успешно удалён'}), 200
    else:
        return jsonify({'error': f'Файл или директория {file_path} не найдены'}), 404

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5555)


#curl.exe -X PUT --data-binary "@D:\output.txt" http://localhost:5555/docs/report.txt
#curl.exe -X DELETE http://localhost:5555/docs/report.txt
# curl.exe http://localhost:5555/docs
#curl.exe -I -X HEAD http://localhost:5555/docs/report.txt






