# grpcdotnet


## if you need venv
```
python -m venv c:\Users\User\venv

c:\Users\User\venv\Scripts\activate

upgrade pip python.exe -m pip install --upgrade pip

pip install -r requirements.txt

python async_greeter_server.py
```

## keygen

1. **`ca.key`** is a private key.
2. **`ca.pem`** is a public certificate.


1. **`server.key`** is the server’s private key.
2. **`server.csr`** is an intermediate file.
3. **`server.pem`** is the server’s public certificate.

openssl req -x509 -nodes -newkey rsa:4096 -keyout ca.key -out ca.pem -subj /O=me

openssl req -nodes -newkey rsa:4096 -keyout server.key -out server.csr -subj /CN=localhost

openssl x509 -req -in server.csr -CA ca.pem -CAkey ca.key -set_serial 1 -out server.pem