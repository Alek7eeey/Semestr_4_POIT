<template>
  
  <TopSite :Times="Times" 
           :infoAboutEarning="infoAboutEarning" 
           :points="points"
           :infoAboutCourses="infoAboutCourses"/>

  <WhatWeDo :title="dataForWhatWeDo.title"
            :context="dataForWhatWeDo.context"
            :img="dataForWhatWeDo.img"/>

  <Start :infoBlocks="infoBlocks"
         :count="infoBlocks.length"/>

  <Advantages :informationAdv = "informationAdv"/>

  <Partners :imageUrl="imageUrl"/>

  <Program :items="ProgramItems"/>

  <Teachers :informationTeacher="informationTeacher"/>

  <Footer :image1="IconVK" 
          :image2="IconYouTube" 
          :image3="IconFacebook" 
          :image4="IconInst" />
  
</template>

<script>
  import Start from "./components/Start/Start.vue";
  import TopSite from "./components/TopSite.vue";
  import WhatWeDo from "./components/WhatWeDo/WhatWeDo.vue";
  import Advantages from "./components/Advantages/Advantages.vue";
  import Partners from "./components/Partners/Partners.vue";
  import Program from "./components/Program/Program.vue";
  import Teachers from "./components/Teachers/Teachers.vue";
  import Footer from "./components/Footer/Footer.vue";
  import getDatas from "./assets/Scripts/getDatas.js";
  
  export default {
    mounted(){
      this.initDate();

      getDatas("http://localhost:5173/infoBlocks.json").then(data => this.infoBlocks = data.data);
      getDatas("http://localhost:5173/points.json").then(data => this.points = data.data);
      getDatas("http://localhost:5173/date.json").then(data => {
        const date = new Date(data.data.date);
        const dateNow = Date.now();

        const dur = date.getTime() - dateNow;

        this.date.day = Math.floor(dur / (1000 * 60 * 60 * 24));
        this.date.hour = Math.floor((dur / (1000 * 60 * 60)) % 24);
        this.date.minute = Math.floor((dur / (1000 * 60)) % 60);
        this.date.second = Math.floor((dur / 1000) % 60);
      });
    },

    data()
    {
      return {
        // информация о блоках в контейнере Быстрый старт
        infoBlocks: [],


        // информация для блока "Чем мы занимаемся"
        dataForWhatWeDo: {
          title: "Чем мы занимаемся?", 
          context: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Eget neque, dignissim et feugiat elit augue in suspendisse egestas. Dictum vestibulum mi et sed nunc, orci fermentum vestibulum, morbi. Et neque, adipiscing sapien sem senectus praesent aenean consequat. Aenean facilisi turpis aliquet fringilla. Nunc sem felis sed interdum feugiat mattis elit, sollicitudin. Quam pharetra rhoncus risus, cursus id elementum aliquet. Nullam turpis arcu malesuada arcu interdum placerat nisi, lobortis. ", 
          img: "./../../assets/Images/whatWeDo.svg",
        },

        // пункты навигационого меню
        points: [],
        
        // Информация о курса.
        infoAboutCourses:[
          {
            text: "Учеников всего:",
            count: 200
          },
          {
            text: "Успешно закончили курс:",
            count: 190
          }
        ],

        infoAboutEarning: {
          text: "Заработано учениками:",
          count: "800 000₽"
        },

        // объект для высчита времени до начала курсов

        date: {
          day: 18,
          hour: 18,
          minute: 18,
          second: 18,

          addSecond()
          {
           this.second -= 1;

            if(this.getSecond() === -1)
            {
              this.minute -= 1;
              this.second = 59;

              if(this.getMinute() === -1)
              {
                this.hour -= 1;
                this.minute = 59;

                if(this.getHour() === -1)
                {
                  this.day -= 1;
                  this.hour = 23;
                }
              }
            }
          },

          getDay()
          {
            return this.day;
          },

          getHour()
          {
            return this.hour;
          },

          getMinute()
          {
            return this.minute;
          },

          getSecond()
          {
            return this.second;
          }
        },
        times: [
          {
            count: 18,
            system: "Дней"
          },
          {
            count: 18,
            system: "Часов"
          },
          {
            count: 18,
            system: "Минут"
          },
          {
            count: 18,
            system: "Секунд"
          }
        ],

        informationAdv: [
          {
            image: "http://localhost:5173/image/icon-1.svg",
            headerText: "Только практические навыки в работе",
            text: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Netus eget velit quisque accumsan amet tortor. Velit, volutpat egestas fringilla mi porttitor tempus. Placerat dui."
          },
          
          {
            image: "http://localhost:5173/image/icon-2.svg",
            headerText: "Работа на самом современном оборудовании",
            text: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Netus eget velit quisque accumsan amet tortor. Velit, volutpat egestas fringilla mi porttitor tempus. Placerat dui."
          },

          {
            image: "http://localhost:5173/image/icon-3.svg",
            headerText: "Сертификация по окончании обучения",
            text: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Netus eget velit quisque accumsan amet tortor. Velit, volutpat egestas fringilla mi porttitor tempus. Placerat dui."
          }
        ],

        //фото партнёров
        imageUrl: "http://localhost:5173/image/logoPartner.svg",

        //программа обучения
        ProgramItems: [
          {id:1, headerText: "Неделя №1", text: "Красивая часть курса, которая помогает в успехе"},
          {id:2, headerText: "Неделя №2", text: "Красивая часть курса, которая помогает в успехе"},
          {id:3, headerText: "Неделя №3", text: "Красивая часть курса, которая помогает в успехе"},
          {id:4, headerText: "Неделя №4", text: "Красивая часть курса, которая помогает в успехе"},
          {id:5, headerText: "Неделя №5", text: "Красивая часть курса, которая помогает в успехе"},
          {id:6, headerText: "Неделя №6", text: "Красивая часть курса, которая помогает в успехе"},
          {id:7, headerText: "Неделя №7", text: "Красивая часть курса, которая помогает в успехе"},
        ],

        //преподаватели
        informationTeacher:[
          {
            urlPhoto: "http://localhost:5173/image/Ellipse2.png",
            nameOfTeacher: "Дмитрий Иванов",
            positionOfTeacher: "Специалист по видеокартам",
            description: "Очень хороший учитель"
          },
          {
            urlPhoto: "http://localhost:5173/image/Ellipse3.png",
            nameOfTeacher: "Дмитрий Иванов",
            positionOfTeacher: "Специалист по видеокартам",
            description: "Очень очень хороший учитель"
          },
          {
            urlPhoto: "http://localhost:5173/image/Ellipse4.png",
            nameOfTeacher: "Дмитрий Иванов",
            positionOfTeacher: "Специалист по видеокартам",
            description: "Очень очень очень хороший учитель"
          }
        ],

        //footer
        IconVK: "http://localhost:5173/image/facebook.svg",
        IconYouTube: "http://localhost:5173/image/youtube.svg",
        IconFacebook: "http://localhost:5173/image/facebook.svg",
        IconInst: "http://localhost:5173/image/instagram.svg"
      }
    },

    components: {
    TopSite,
    WhatWeDo,
    Start,
    Advantages,
    Partners,
    Program,
    Teachers,
    Footer
},

    computed:
    {
      Times()
      {
        return this.times.map(el => {
          switch(el.system)
          {
              case 'Дней':
                el.count = this.date.getDay();
                break;
              case 'Часов':
                el.count = this.date.getHour();
                break;
              case 'Минут':
                el.count = this.date.getMinute();
                break;
              case 'Секунд':
                el.count = this.date.getSecond();
                break;
          }

          return el;
        });
      }
    },
    methods:
    {
      initDate()
      {
        const index = setInterval(() => {
          this.date.addSecond();
          if(
            this.date.getDay() === 0 && 
            this.date.getHour() === 0 && 
            this.date.getMinute() === 0 && 
            this.date.getSecond() === 0)
            {
              clearInterval(index);
            }
        }, 1000);
      }
    },
  }

</script>

<style lang="scss">
  @import './assets/index.scss';

  .back-for-header{
    background-image: url('./assets/Images/header-back.png');
    background-repeat: no-repeat;
    background-attachment: fixed;
    background-size: cover;
    background-position: 0 0 0 0;
    min-height: 700px;
  }
  .time-blocks
  {
    @include flexer(30px, flex-start, center);
  }
</style>