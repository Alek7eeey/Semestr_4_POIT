<template>

<div class="start-block padding">
    <header class="header-start-block">
        <div class="img-and-header-text">
            <img src="./../../assets/Images/header-for-start.svg" alt="" class="logo">
            <div class="header-text">
                Быстрый старт
            </div>
        </div>
        <div class="start-block-info">
            Больше 90% учеников прошли полный курс и смогли собрать свой первый компьютер
        </div>
    </header>

    <footer class="footer-start-block">

        <StartInfoBlock :style="{ width: `${100 / this.count}%` }"
                        v-for="(info, index) of infoBlocks"
                        :percent="info.percent"
                        :progress_count="info.progress_count"
                        :context="info.context"/>

    </footer>
</div>

</template>

<script>
    import StartInfoBlock from './StartInfoBlock.vue';

    export default
    {
        props: ['infoBlocks', 'count'],
    
        components: { StartInfoBlock },
    }
</script>

<style lang="scss">
    @import "./../../assets/index.scss";
    .start-block
    {
        @include flexer(49px, space-between, flex-start, column);
        
        width: 100%;
        padding: 30px;

        .footer-start-block
        {
            display: flex;
            justify-content: flex-start;
            flex-wrap: wrap;
            @media (max-width: 400px) {
                gap: 20px;
                flex-direction: column;
            }
        }

        .header-start-block
        {
            @include flexer(20px, center, flex-start, column);

            .img-and-header-text
            {
                @include flexer(20px, flex-start);
                flex-wrap: wrap;

                .header-text
                {
                    font-family: 'Roboto';
                    font-style: normal;
                    font-weight: 700;
                    font-size: 48px;
                    line-height: 140%;
                    color: #FFFFFF;
                }
            }
        }

        .start-block-info
        {
            font-family: 'Roboto';
            font-style: normal;
            font-weight: 400;
            font-size: 16px;
            line-height: 160%;
            color: #FFFFFF;
            opacity: 0.5;
            max-width: 411px;
            width: 100%;
            margin-left: 25px;
        }

        .start-info-block:nth-child(2n+1) .block-progress
        {
            background: linear-gradient(94.26deg, #C89AFC 9.51%, #7C6AFA 90.23%);
            width: 100%;
            transform: rotate(180deg);
        }
        .start-info-block:nth-child(2n) .block-progress
        {
            background: linear-gradient(94.26deg, #C89AFC 9.51%, #7C6AFA 90.23%);
            width: 100%;
        }
    }
</style>
