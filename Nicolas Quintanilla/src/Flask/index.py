from flask import Flask

app = Flask(__name__)

@app.route('/')
def home():
    return 'Hello World'

@app.route('/about')
def about():
    return "HOLA QUE TAL"

if __name__=='__main__':
    app.run(debug=True)
