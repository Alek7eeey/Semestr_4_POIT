<script>
    import PointMenu from './PointMenu.vue';

    export default {
        props: ["points"],
        components: { PointMenu },
    }
</script>

<template>
    <header class='header-site'>
        <img src="./../assets/Images/logo.svg"/>

        <ul class='header-menu'>
            <PointMenu
                v-for="point of points"
                :point="point"
            />
        </ul>

        <button class="toCabinet">Зайти в кабинет</button>
    </header>
</template>

<style lang="scss">
    @mixin flexer($value : 0)
    {
        display: flex;
        justify-content: center;
        align-items: center;
        gap: $value;
    }

    @mixin flexerSB
    {
        display: flex;
        justify-content: space-between;
        align-items: center;
    }

    .header-site {
        @include flexerSB;
        width: 100%;
    
        .header-menu {
            @include flexer;
            flex-wrap: wrap;
            .point-menu
            {
                width: 136px;
                height: 40px;
                @include flexer;
            }
         }

        .toCabinet
        {
            width: 183px;
            height: 44px;
            background: linear-gradient(94.26deg, #C89AFC 9.51%, #7C6AFA 90.23%);
            border-radius: 50px;
            display: flex;
            flex-direction: row;
            justify-content: center;
            align-items: center;
            padding: 10px 30px;
            gap: 10px;

            color: white;
            outline: none;
            border: none;
            font-style: normal;
            font-weight: 400;
            font-size: 16px;
            line-height: 150%;
        }
}
</style>