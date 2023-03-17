<template>
    <button class="doOrder"
            @click="$event => click()" v-bind:style="{ boxShadow: boxShadow }" v-on:mouseover="addShadow" v-on:mouseleave="removeShadow">{{ text }}</button>
</template>

<script>
    export default {
        props: ["text", "click"],
        methods: {

        addShadow() {
        this.boxShadow = "2px 2px 10px rgba(222, 123, 0, 0.5)";
        },

        removeShadow() {
        this.boxShadow = "none";
        }
  },
        data() {
            return {
            boxShadow: "none"
            };
        }
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