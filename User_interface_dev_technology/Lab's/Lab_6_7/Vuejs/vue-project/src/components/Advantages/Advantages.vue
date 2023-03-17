<template>
<div class="wrapperForAdv">
<div class="Text">
    Получите профессию прямо сейчас
</div>

<footer class="InfoWithAdv">
        <Info v-for="info of informationAdv"
        :image = "info.image"
        :headerText = "info.headerText"
        :text = "info.text"
        />
</footer>

</div>
</template>

<script>

import Info from "../Advantages/infoAboutAdv.vue";
  export default
    {
        props: ['informationAdv'],
        components: { Info }
    }

</script>

<style lang="scss">
@import './../../assets/index.scss';

    .wrapperForAdv{
        @include flexer(49px, space-between, center, column);
        padding: 25px 80px;

        .Text
        {
                font-family: 'Roboto', sans-serif;
                font-style: normal;
                font-weight: 700;
                font-size: 48px;
                line-height: 140%;
                color: #FFFFFF;
        }

        .InfoWithAdv
        {
            display: flex;
            flex-direction: row;
            flex-wrap: wrap;
            text-align: center;
            gap: 17px;
        }
    }

</style>