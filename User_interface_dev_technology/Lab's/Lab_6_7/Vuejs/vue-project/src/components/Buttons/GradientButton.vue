<template>
    <button class="doOrder"
            @click="$event => click()">{{ text }}</button>
</template>

<script>
    export default {
        props: ["text", "click"]
    }
</script>

<style lang="scss">
.doOrder {
        background: linear-gradient(94.78deg, #DF5950 11.19%, #451046 93.72%);
        border-radius: 50px;
        font-family: 'Roboto';
        padding: 10px 30px;
        font-style: normal;
        font-weight: 700;
        font-size: 16px;
        line-height: 150%;
        text-align: center;
        color: #FFFFFF;
        border: none;
    }
</style>