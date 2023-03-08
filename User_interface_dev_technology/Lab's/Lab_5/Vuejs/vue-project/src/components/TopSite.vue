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

<button class="doOrder">Заказать курс!</button>

<div class="info-about-courses">
  <infoAboutCourses 
  v-for="info of infoAboutCourses"
  :info="info"
  />
</div>

<div class="block-progress">
  <InfoAboutCourses :info="infoAboutEarning" style="width: 280px;"/>

  <div class="progress">
    <div class="line-fill"></div>
    <div class="line-none"></div>
  </div>

  <div class="diap-progress">
    <span class="start">0</span>
    <span class="to">1 000 000₽</span>
  </div>
  
</div>

</div>

</div>
</template>

<script >
    import HeaderSite from "./HeaderSite.vue";
    import TimeBlock from "./TimeBlock.vue";
    import InfoAboutCourses from "./InfoAboutCourses.vue";

    export default 
    {
        props: ["Times", "infoAboutEarning", "points", "infoAboutCourses"],
        name: "TopSite",

        components: {
            HeaderSite,
            TimeBlock,
            InfoAboutCourses
        }
    }
</script>