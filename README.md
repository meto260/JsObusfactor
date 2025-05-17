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
https://github.com/meto260/JsObusfactor.git
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
// Temel JavaScript fonksiyonları
function topla(a, b) {
    return a + b;
}

// Nesne yönelimli programlama örneği
class Kisi {
    constructor(ad, yas) {
        this.ad = ad;
        this.yas = yas;
    }

    tanit() {
        return `Benim adım ${this.ad}, ${this.yas} yaşındayım.`;
    }
}

// Test edilecek fonksiyonlar
const sonuc = topla(5, 3);
const kisi = new Kisi('Ahmet', 25);
console.log(kisi.tanit());
console.log('Toplam:', sonuc);
```

##### Output (test_obfuscated. js):
```javascript

(function() {
    var _0xd9144e = atob('ZnVuY3Rpb24gXyQ3NGQzZjIoKXsKDQogIGlmKHR5cGVvZiB3aW5kb3chPT0ndW5kZWZpbmVkJyl7c2V0VGltZW91dChmdW5jdGlvbigpe18kajBiN2YxNSgyKX0sMCl9CmZ1bmN0aW9uIF8kJDlkMzdkMWQzKHMpe3JldHVybiBkZWNvZGVVUklDb21wb25lbnQoYXRvYihzKS5zcGxpdCgnJykubWFwKGZ1bmN0aW9uKGMpe3JldHVybiAnJScrKCcKDQp9Cg0KZnVuY3Rpb24gXyRjOTMzNDMoKXsKDQogIDAwJytjLmNoYXJDb2RlQXQoMCkudG9TdHJpbmcoMTYpKS5zbGljZSgtMil9KS5qb2luKCcnKSl9O2Z1bmN0aW9uIHRvcGxhKG4sdCl7cmV0dXJuIG4rdH1jbGFzcyBLaXNpe2NvbnN0cnVjdG9yKG4sdCl7dGhpcy5hZD1uO3RoaXMueWFzPXR9dGFuaXQoKXtyZXR1cm5gQmVuaW0gYWTEsW0gJHt0aGlzCg0KfQoNCmZ1bmN0aW9uIF8kYTExZWIxKCl7Cg0KICAuYWR9LCAke3RoaXMueWFzfSB5YcWfxLFuZGF5xLFtLmB9fWNvbnN0IHNvbnVjPXRvcGxhKDUsMyksa2lzaT1uZXcgS2lzaShfJCQ5ZDM3ZDFkMygnUVdodFpYUT0nKSwyNSk7Y29uc29sZS5sb2coa2lzaS50YW5pdCgpKTtjb25zb2xlLmxvZyhfJCQ5ZDM3ZDFkMygnVkc5d2JHRnRPZz09Jyksc29udWMpOwoNCn0KDQooZnVuY3Rpb24oKXsKDQogIF8kNzRkM2YyKCk7Cg0KICBfJGM5MzM0MygpOwoNCiAgXyRhMTFlYjEoKTsKDQp9KSgpOwoNCg==');
    var _0x0eadf9 = function(s) {
        return decodeURIComponent(s.split('').map(function(c) {
            return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
        }).join(''));
    };
    try {
        if (!/\\[native code\\]/.test(window.eval.toString())) {
            throw new Error('Debugger detected');
        }
        eval(_0x051287);
    } catch(e) {
        return eval(_0xeb1c46);
    }
})();

```

#### License

This project was licensed under MIT license.