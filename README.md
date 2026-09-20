## Autopesula Tellimused

Projekt kujutab endast C# ja WPF-põhist töölauarakendust autopesula tellimuste haldamiseks. Rakendus võimaldab sisestada uusi tellimusi, muuta olemasolevaid andmeid ning kustutada vajaduse korral valitud kirjeid

---

## Rakenduse kirjeldus

Rakendus pakub lihtsat liidest pesula töö korraldamiseks. Kasutaja sisestab sõiduki registreerimisnumbri, valib sõiduki tüübi ning soovitud pesuprogrammi. Süsteem arvutab automaatselt teenuse hinna ja kestuse ning kuvab kõik andmed koondtabelis koos üldise statistikaga

---

## Tehniline ülevaade

`AutopesulaTellimused.Core`: Klassiraamatukogu, mis sisaldab andmemudeleid ja loogikat

`AutopesulaTellimused.WpfApp`: WPF-rakendus kasutajaliidese ja sündmuste töötlemiseks

---

## Kuidas programmiga töötada

- Sisesta sõiduki registreerimisnumber (2 kuni 10 märki)

- Vali rippmenüüst sõiduki liik (Sedan, SUV, Van)

- Vali rippmenüüst pesuprogramm (Express, Standard, Premium)

- Uue kirje lisamiseks klõpsa nupul **Lisa tellimus**

- Olemasoleva kirje muutmiseks vali see tabelist, tee vajalikud muudatused väljadel ja klõpsa nupul **Muuda valitud**

- Kirje eemaldamiseks vali see tabelist ning klõpsa nupul **Kustuta valitud**

---

## Veastsenaariumid ja teated

### Valed sisendandmed:

**Tegevus**: Kasutaja jätab reg-numbri sisestamata või sisestab ainult ühe tähe

<img width="730" height="484" alt="Знімок екрана 2026-09-20 130922" src="https://github.com/user-attachments/assets/5357b5bc-abff-48f0-bd50-2c87ac1a35bb" />

**Tegevus**: Reg-number on sisestatud, kuid sõiduki liik on valimata

<img width="725" height="484" alt="Знімок екрана 2026-09-20 130937" src="https://github.com/user-attachments/assets/2454dfdd-3b60-48ab-8d9f-c12b4ce2f87d" />

**Tegevus**: Pesuprogrammi pole valitud

<img width="728" height="481" alt="Знімок екрана 2026-09-20 130945" src="https://github.com/user-attachments/assets/f048524b-f3a8-416d-8c6f-667930867d1f" />

**Tegevus**: Kasutaja üritab lisada teist korda auto samasuguse numbriga 123ABC

<img width="727" height="485" alt="image" src="https://github.com/user-attachments/assets/e5a63cce-42da-404f-8c78-515be1da07a7" />

**Tegevus**: Kasutaja vajutab nuppu "Kustuta valitud", ilma et oleks tabelist ühtegi rida valinud

<img width="728" height="484" alt="image" src="https://github.com/user-attachments/assets/41f1ae10-3880-4123-80ec-ddd1c81b5a0f" />

---
## Näide täidetud tabelist

<img width="727" height="479" alt="image" src="https://github.com/user-attachments/assets/309e4f59-ab48-4ac8-a1dc-46c648a76d73" />

## Tabel pärast kirje nr 2 kustutamist

<img width="727" height="483" alt="image" src="https://github.com/user-attachments/assets/4b136845-54c0-4f54-af5a-26cc94e42212" />

## Tabel pärast kirje nr 2 muutmist (Pesuprogram "Premium" -> "Standard")

<img width="725" height="485" alt="image" src="https://github.com/user-attachments/assets/391e56f5-fd24-4415-bdda-fb093bfb9971" />
