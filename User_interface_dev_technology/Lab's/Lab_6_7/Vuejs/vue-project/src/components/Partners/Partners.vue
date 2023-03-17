<template>
<div class="wrapperPartners">
    <div class="text">
        <div class="phot"><img src="/image/icon-heading.png" alt=""></div>
        <div class="textSlog">Партнёры - топовые бренды</div>
    </div>

    <div class="photoGallery">
        <Photo :imageUrl="imageUrl" />
    </div>
</div>
</template>

<script>
import Photo from "../Partners/PartnersPhoto.vue";
export default {
    props: {
    imageUrl: {
      type: String,
      required: true
    }
  },
    components: { Photo }
}
</script>

<style lang="scss" scoped>

@import './../../assets/index.scss';
.wrapperPartners
{
    display: flex;
    flex-direction: column;
    gap: 89px;
    padding: 25px 80px;
    .text
    {
        font-family: 'Roboto', sans-serif;
            font-style: normal;
            font-weight: 700;
            font-size: 48px;
            color: #FFFFFF;
            display: flex;
            flex-direction: row;
            align-items: center;
            flex-wrap: wrap;
            @media (max-width: 1000px) {
                font-size: 38px;

                @media (max-width: 880px) {
                    font-size: 28px;
                    justify-content: center;

                    img{
                        width: 97px !important;
                    }
                }
            }
    }

    .text img{
        padding: 0;
        width: 127px;
        margin-right: 20px;
    }
    .name{
        display: flex;
        justify-content: start;
    }

    .photoGallery
    {
        display: flex;
        flex-direction: row;
        align-items: center;
        justify-content: center;
        width: 100%;
        text-align: center;
        flex-wrap: wrap;
        gap: 10px;
    }
}
</style>