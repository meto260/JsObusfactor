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