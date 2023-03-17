<template>
    <section class="whatWeDo padding">
        <img src="./../../assets/Images/whatWeDo.svg" alt="What we do?" />
        <div class="text">
            <div class="title">
                {{ title }}
            </div>
            <div class="context">
                {{ context }}
            </div>
        </div>
    </section>
</template>

<script>

export default {
    props:["title", "context", "img"],

    name: "WhatWeDo",
}

</script>

<style lang="scss" scoped>
    @import "./../../assets/index.scss";
    .whatWeDo
    {
        @include flexer(139px);
        
        width: 100%;
        flex-wrap: wrap;

        img{
            max-width: 526px;
            width: 100%;    
        }
        .text
        {
            display: flex;
            flex-direction: column;
            gap: 45px;
            max-width: 700px;
            width: 100%;
            div
            {
                color: white;

                &.title
                {
                    font-family: 'Roboto', sans-serif;
                    font-style: normal;
                    font-weight: 700;
                    font-size: 48px;
                    line-height: 140%;
                    color: #FFFFFF;
                }

                &.context
                {
                    font-family: 'Roboto', sans-serif;
                    font-style: normal;
                    font-weight: 400;
                    font-size: 16px;
                    line-height: 160%;
                    color: #FFFFFF;
                }
            }
        }
    }
</style>
