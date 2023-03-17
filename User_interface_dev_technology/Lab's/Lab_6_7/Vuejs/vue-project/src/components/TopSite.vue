<template>
<div class="topSite">


<div class="padding back-for-header">
    <HeaderSite :points="points"/>

    <div class="center-block">
      <span class="start-title">Первый курс по компьютерной сборке</span>
      <div class="time-blocks">

        <TimeBlock 
        v-for="time of Times"
        :data="time"
        />

      </div>
    </div>
</div>

<div class="info-block padding">

<GradientButton :text="textButton"/>

<div class="info-about-courses">

  <InfoAboutCourses 
  v-for="info of infoAboutCourses"
  :info="info"
  />

</div>

<div class="block-progress">

  <InfoAboutCourses :info="infoAboutEarning"
                    style="width: 280px"/>

  <div class="progress">
    <div class="line-fill"
         :style="{ width: `${this.Percent}%` }"></div>
    <div class="line-none"
         :style="{ width: `${100 - this.Percent}%` }"></div>
  </div>

  <div class="diap-progress">
    <span class="start">0</span>
    <span class="to">{{ this.to }}₽</span>
  </div>
  
</div>

</div>

</div>
</template>

<script >
    import HeaderSite from "./HeaderSite.vue";
    import TimeBlock from "./TimeBlock.vue";
    import InfoAboutCourses from "./InfoAboutCourses.vue";
    import GradientButton from "./Buttons/GradientButton.vue";

    export default 
    {
        props: ["Times", "infoAboutEarning", "points", "infoAboutCourses"],
        name: "TopSite",
        components: {
    HeaderSite,
    TimeBlock,
    InfoAboutCourses,
    GradientButton
},

        data() {
          return {
            to: "1 000 000",
            textButton: "Заказать курс",
          }
        },

        computed: {
          Percent() {
            const str = (String)(this.infoAboutEarning.count.replace(' ', ''));
            const earned = (Number)(str.substring(0, str.length - 1).replace(' ', ""));
            const res = earned / (Number)(this.to.replace(/ /, '').replace(' ', '')) * 100;
            return res;
          }
        }
    }
</script>

<style lang="scss">
  .time-blocks {
    flex-wrap: wrap;
    @media (max-width: 580px) {
      justify-content: center !important;
    }
  }
</style>