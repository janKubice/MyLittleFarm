using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WikiText : MonoBehaviour
{
    public Text wikiText;

    public void setText(string itemName)
    {
        switch (itemName)
        {
            case "Paprika":
                wikiText.text = pepper;
                break;
            case "Rajče":
                wikiText.text = tomato;
                break;
            case "Okurka":
                wikiText.text = cucumber;
                break;
            case "Kukuřice":
                wikiText.text = corn;
                break;
            case "Rýč":
                wikiText.text = spade;
                break;
            case "Konev":
                wikiText.text = can;
                break;
            case "GreenGun":
                wikiText.text = greenGun;
                break;
            case "Plodiny":
                wikiText.text = crops;
                break;
            case "Nástroje":
                wikiText.text = tools;
                break;
            case "Wiki":
                wikiText.text = wiki;
                break;
            case "Ostatní":
                wikiText.text = other;
                break;
            case "Dům":
                wikiText.text = house;
                break;
            case "Obchod":
                wikiText.text = shop;
                break;
            case "Steve":
                wikiText.text = Steve;
                break;
            case "Stevinka":
                wikiText.text = Stevinka;
                break;
        }
    }

    private string pepper = "Paprika se jí syrová nebo tepelně upravovaná. \nPři vaření se používají zejména druhy Capsicum annuum a Capsicum frutescens, která jsou vhodné k plnění (sýrem, masem nebo rýží) \n" +
        "Čerstvé papriky se přidávají do salátů.Rovněž se dají nakládat nebo sušit.";

    private string wiki = "Souhrn všeho důležitého co byjste potřebovali vědět.\n" +
        "Všechny obsažené texty jsou převzaty z wikipedie.";

    private string tools = "Nástroj je pracovní prostředek, pomůcka k zpracování něčeho (pracovní nástroj, řemeslnický nástroj, chirurgický nástroj aj.),\n" +
        " příp. výrobní pomůcka sloužící při ručním nebo strojním obrábění ke změně velikosti nebo tvaru opracovávaného předmětu, k upnutí předmětu atp.";

    private string spade = "Rýč je zahradnický nástroj určený k obracení či k vyrývání zeminy.";

    private string can = "Konev je zahradnická a zahrádkářská nádoba, která je určena pro ruční zalévání rostlin na zahradě.";

    private string greenGun = "Neboli ZelenoPifka slouží k přeměně nehezké půdy v anglický trávník";

    private string crops = "Užitkové rostliny, neboli plodiny jsou rostliny dávající člověku ať už přímo, či nepřímo nějaký užitek.\n" +
        "Používají se velmi často jako potrava nebo jako krmivo.";

    private string tomato = "Rajče jedlé, též lilek rajče je trvalka bylinného charakteru pěstovaná jako jednoletka.\n" +
        "Patří do čeledi lilkovitých. Pochází ze Střední a Jižní Ameriky.\n" +
        "Plodem je bobule zvaná rajče, původně rajské jablko, proto se rajče řadí mezi plodovou zeleninu.";

    private string cucumber = "Okurka setá je rostlina z čeledi tykvovité.\n" +
        "Pochází z vlhkých a teplých krajů Indie a Číny. Její tmavě zelený plod je nazýván okurka.\n" +
        "Mezi základní druhy okurky patří okurka polní a okurka salátová.";

    private string corn = "Kukuřice je rod jednoděložných rostlin z čeledi lipnicovité.\n" +
        "Český název kukuřice patří mezi novotvary vytvořené v 19. století Janem Svatoplukem Preslem.\n" +
        "Podobný název je i v jiných slovanských jazycích.";

    private string other = "Ostatní důležité záležitosti.";

    private string house = "Dům je stavení, zpravidla obytné\n" +
        "Dům může sloužit i k různým jiným účelům, pro výrobu, skladování, administrativu a podobně, základní význam však je spojen s bydlením.";

    private string shop = "Obchod neboli nákup a prodej, případně komerce, je lidská činnost, která spočívá ve směňování zboží nebo služeb za peníze, případně za jiné zboží nebo služby (barterový obchod).\n" +
        "Někdy je realizovan prostředníky za účelem dosažení zisku.";

    private string Steve = "Mužská herní postava. Jeho jméno vzniklo dle světoznámé legendy Steva v Minecraftu.";

    private string Stevinka = "Dámská herní postava. Její jméno vzniklo odpovezním z jména Steve (nečekaně). Neimplementovaná";
}
