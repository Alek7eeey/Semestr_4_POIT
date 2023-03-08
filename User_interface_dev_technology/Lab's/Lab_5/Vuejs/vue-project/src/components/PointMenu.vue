<script>

    export default {
        name: "PointMenu",
        props: ["point"],
    }

</script>

<template>
    <a class="point-menu" :href="point.href">
        <li>
            {{ point.text }}
        </li>
    </a>
</template>

<style lang="scss" scoped>
    @mixin afterAnim {
        position: relative;

        &::after {
            content: "";
            position: absolute;
            top: 35px;
            height: 10px;
            width: 100%;
            border-top: 1px solid white;
            visibility: hidden;
            transition: all .2s ease-in-out;

            transform: rotateY(90deg);
        }

        &:hover
        {
            &::after {
                visibility: visible;
                transform: rotate(0deg);
            }
        }
    }

    .point-menu
    {
        font-family: 'Roboto', sans-serif;
        font-style: normal;
        font-weight: 400;
        font-size: 16px;
        line-height: 150%;
        text-align: center;
        color: #FFFFFF;
        display: flex;
        justify-content: center;
        align-items: center;

        @include afterAnim;
    }
</style>