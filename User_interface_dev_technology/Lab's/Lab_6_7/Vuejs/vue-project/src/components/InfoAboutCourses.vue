<template>
    <div class="info">
        <span class="info-text">{{ info.text }}</span>
        <span class="info-count">{{ info.count }}</span>
    </div>
</template>

<script lang="ts">

export default {
    props: ["info"]
}

</script>

<style lang="scss" scoped>
    @import './../assets/index.scss';
    .info
    {
        width: 100%;
        @include flexer(0, space-between);
        .info-text
        {
            font-family: 'Roboto';
            font-style: normal;
            font-weight: 400;
            font-size: 16px;
            line-height: 150%;
            color: #FFFFFF;
            opacity: 0.4;
        }

        .info-count
        {
            font-family: 'Roboto';
            font-style: normal;
            font-weight: 700;
            font-size: 16px;
            line-height: 150%;
            color: #FFFFFF;
        }
    }

</style>
