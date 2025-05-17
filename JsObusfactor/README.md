# JavaScript Code Mixer (Obfuscator)

This project is a compelling the reading by mixing JavaScript codes. NET application. You can protect your JavaScript code using different mixing strategies.

#### Features

- String encryption
- Add unnecessary code
- Complexizing control flow
- Wrapping with eval function

#### Requirements

- . NET 9.0 or above
- Visual Studio 2022 or later (for development)

#### Installation

1. clone project:
```bash
https://github.com/user/ JsObusfactor.git
```

2. Go to the project directory:
```bash
CD JsObusfactor
```

3. compile project:
```bash
dotnet build
```

#### Usage

To run the project:
```bash
dotnet run
```

#### Test Sample

##### Input (test. js):
```javascript
functionaccountSum(a,b) {
return a + b;
News

const result = calculate(5, 3);
console.log("Total:", result);
```

##### Output (test_obfuscated. js):
```javascript
var_0x4f2d=["\x72\x65\x74\x75\x72\x6E","\x6C\x6F\x67","\x54\x6F\x70\x6C\x61\x6D\x3A"];
function_0x7d3f(_0x4f2d,_0x7d3f){turn_0x4f2d+_0x7d3f;}
eval("functionaccountSum(a,b){" +_0x4f2d[0] + "_0x7d3f(a,b);}");
var_0x3d2f=accountSum(5,3);
console[_0x4f2d[1]](_0x4f2d[2],_0x3d2f);
```

#### Contribution

1. Fork this warehouse
2. Create a new feature (`git checkout -b new-tozellik`)
3. commit your changes (`git commit-am 'New feature added')
4. Make push to your department (`git push new origin)
5. Create Pull Request

#### License

This project was licensed under MIT license.