using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using EUGamesApp.Models;



namespace EUGamesApp.ViewModels
{
    public class EventsViewModel : BaseViewModel
    {
        private List<string> eveNames;
        private List<string> icons;
        public List<Place> places;
        public List<Place> tempPlaces;
        private ObservableCollection<Date> date { get; set; }
        private List<string> firstNames;
        private List<string> secNames;
        private List<string> otherNames;
        private List<string> dates;

        public ObservableCollection<Event> Items { get; set; }

        public EventsViewModel()
        {
            Title = "Расписание";
            eveNames = new List<string> { "Церемония открытия", "Церемония закрытия", "Акробатика спортивная", "Аэробика спортивная", "Бадминтон", "Баскетбол 3х3", "Бокс", "Велосипедный спорт – трек", "Борьба", "Гимнастика спортивная", "Велосипедный спорт – шоссе", "Гимнастика художественная", "Гребля на байдарках и каноэ", "Дзюдо", "Каратэ", "Легкая атлетика", "Настольный теннис", "Пляжный футбол", "Прыжки на батуте", "Самбо", "Стрельба из лука", "Стрельба пулевая", "Стрельба стендова" };
            icons = new List<string> {
                "Acrobatics.png",
                "Aerobics.png",
                "Archery.png",
                "Atletics.png",
                "Badminton.png",
                "Basketball.png",
                "BeachFootball.png",
                "Boxing.png",
                "CyclingRoad.png",
                "CyclingTrack.png",
                "Gymnastics.png",
                "Judo.png",
                "Karate.png",
                "Rowing.png",
                "Sambo.png",
                "Shooting.png",
                "ShootingStand.png",
                "SportsGymnastics.png",
                "TableTennis.png",
                "Trampoline.png",
                "Wrestling.png",
                "Ceremony.png"
            };
            places = new List<Place> {
                new Place(53.917261, 27.584840, AppResources.OlympicSportsComplex, "", 0), //улица Калиновского 111
                new Place(53.8951825, 27.558098, AppResources.DinamoStadium, "", 0), //улица Кирова 8
                new Place(53.9107421, 27.54755, AppResources.PalovaArena, "", 0), //проспект Победителей 4
                new Place(53.9507453, 27.706051, AppResources.UruchieSportsPalace, "", 0), //проспект Независимости 196
                new Place(53.9326612, 27.5104683, AppResources.FalconClub, "", 0), //проспект Победителей 20
                new Place(53.936161, 27.4819988, AppResources.MinskArena, "", 0), //проспект Победителей 111
                new Place(53.8445557, 27.6287836, AppResources.ChizhovkaArena, "", 0), //улица Ташкентская 19
                new Place(53.936161, 27.4819988, AppResources.SportsPalace, "", 0), //проспект Победителей 4
                new Place(53.9023858, 27.561511, AppResources.Minsk, "", 0),
                new Place(53.9944815, 27.3139787, AppResources.ZaslavlRegattaCourse, "", 0), //улица Гонолес 1
                new Place(53.924171, 27.518856, AppResources.TennisOlympicCentre, "", 0), //проспект Победителей 63
                new Place(53.956108, 27.716315, AppResources.ShootingCentre, "", 0), //проспект Независимости 195
                new Place(53.954756, 27.712518, AppResources.SportingClub, "", 0)
            };

            tempPlaces = new List<Place>
            {
                new Place(53.920394, 27.593032, "Мемориал Великой Отечественной войны", "", 2),
                new Place(53.917590, 27.588349, "Памятная доска Лукьяновичу Трифону Андреевичу", "", 2),
                new Place(53.918993, 27.589451, "Мемориальная доска заслуженному деятелю науки и техники БССР М. В. Дорошевичу", "", 2),
                new Place(53.921936, 27.597436, "Памятник Почтальону", "", 2),
                new Place(53.920454, 27.597919, "Скульптурная композиция Преемственность белорусской науки", "", 3),

                new Place(53.920357, 27.597769, "Скульптура Лента Мебиуса", "", 2),
                new Place(53.915001, 27.597672, "Мемориальный знак в память о воинах связистах", "", 2),
                new Place(53.915436, 27.587166, "Бондаревский сквер", "", 1),
                new Place(53.916415, 27.585498, "Семья покупателей", "", 2),
                new Place(53.913620, 27.586549, "Бульвар Мулявина", "", 1),
                new Place(53.911368, 27.590382, "Сквер города-побратима Чанчунь", "", 1),
                new Place(53.8488890958488, 27.4577881023288, "1", "", 1),
                new Place(53.8464048418932, 27.4624742567539, "2", "", 2)
            };

            firstNames = new List<string> { "Мужчины", "Мужская", "Женщины", "Женская", "Группы", "Смешанная команда", "Вольная", "Греко-римская", "Смешанный парный рязряд", "Смешанные", "Смешанные пары", "Индивидуальные упражнения" };

            secNames = new List<string> { "Предварительный этап", "Медальный этап", "Финал", "Полуфиналы", "Четвертьфиналы", "Квалификация" };
            
            otherNames = new List<string> { "Индивидуальные прыжки", "Синхронные прыжки", "Индивидуальный классический лук", "Индивидуальный блочный лук", "Командный классический лук", "Классический лук", "Блочный лук", "Пневматический пистолет на 10м", "Пневматическая винтовка на 10м", "Малокалиберный пистолет на 50м", "Малокалиберный пистолет на 25м", "Малокалиберная винтовка из положения лёжа на 50м", "Скоростной малокалиберный пистолет на 25м", "Малокалиберный пистолет на 25м", "Малокалиберная винтовка из трёх положений на 50м", "Траншейный стенд", "Командные соревнования", "Одиночный разряд", "Парный разряд", "Пары", "Групповая гонка", "Индивидуальная гонка с раздельным стартом", "Многоборье" };
            
            dates = new List<string> { "21 Июня, Пт", "22 Июня, Сб", "23 Июня, Вс", "24 Июня, Пн", "25 Июня, Вт", "26 Июня, Ср", "27 Июня, Чт", "28 Июня, Пт", "29 Июня, Сб", "30 Июня, Вc" };


            //ObservableCollection<InfoList> infoList = new ObservableCollection<InfoList>(
            //    new List<InfoElement>
            //        {
            //            new InfoElement(firstNames[0] + secNames[0], "12:30")
            //        },
            //    new List<InfoElement>
            //        {
            //            new InfoElement(firstNames[1] + secNames[0], "11:30")
            //        },
            //    new List<InfoElement>
            //        {
            //            new InfoElement(firstNames[1] + secNames[1], "10:30")
            //        },
            //    new InfoElement(firstNames[0] + secNames[0], "12:30"),
            //    new InfoElement(firstNames[0] + secNames[0], "12:30"),
            //    new InfoElement(firstNames[0] + secNames[0], "12:30")
            //    );
            ObservableCollection<InfoList> infoList = new ObservableCollection<InfoList>()
            {
                new InfoList(new ObservableCollection<InfoElement>
                    {
                        new InfoElement(secNames[0], "12:30"),
                        new InfoElement(secNames[0], "11:30"),
                        new InfoElement(secNames[1], "10:30")
                    }, firstNames[0]),
                new InfoList(new ObservableCollection<InfoElement>
                    {
                        new InfoElement(secNames[0], "12:30"),
                        new InfoElement(secNames[0], "11:30"),
                        new InfoElement(secNames[1], "10:30")
                    }, firstNames[2])
            };
            date = new ObservableCollection<Date>
            {
                new Date(dates[0], infoList),
                new Date(dates[1], infoList),
                new Date(dates[2], infoList),
                //new Date(dates[3], infoList),
                //new Date(dates[4], infoList),
                //new Date(dates[5], infoList),
                //new Date(dates[6], infoList),
                //new Date(dates[7], infoList),
                //new Date(dates[8], infoList)
            };

            Items = new ObservableCollection<Event>() {
                new Event(icons[21], eveNames[0], places[1], date),
                new Event(icons[21], eveNames[1], places[1], date),
                new Event(icons[0], eveNames[2], places[5], date),
                new Event(icons[1], eveNames[3], places[5], date),
                new Event(icons[4], eveNames[4], places[4], date),
                new Event(icons[5], eveNames[5], places[2], date),
                new Event(icons[7], eveNames[6], places[3], date),
                new Event(icons[20], eveNames[7], places[7], date),
                new Event(icons[9], eveNames[8], places[5], date),
                new Event(icons[8], eveNames[9], places[8], date),
                new Event(icons[17], eveNames[10], places[5], date),
                new Event(icons[10], eveNames[11], places[5], date),
                new Event(icons[13], eveNames[12], places[9], date),
                new Event(icons[11], eveNames[13], places[6], date),
                new Event(icons[12], eveNames[14], places[6], date),
                new Event(icons[3], eveNames[15], places[1], date),
                new Event(icons[18], eveNames[16], places[10], date),
                new Event(icons[6], eveNames[17], places[0], date),
                new Event(icons[19], eveNames[18], places[5], date),
                new Event(icons[14], eveNames[19], places[7], date),
                new Event(icons[2], eveNames[20], places[0], date),
                new Event(icons[16], eveNames[20], places[11], date),
                new Event(icons[15], eveNames[20], places[12], date)
            };

        }
    }
}
