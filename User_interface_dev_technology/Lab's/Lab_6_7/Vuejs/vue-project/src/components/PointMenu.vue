
<template>
    <a class="point-menu" 
       @click="$event => linkTo(point.href)">
       
        <li>
            {{ point.text }}
        </li>
    </a>
</template>

<script>

    export default {
        name: "PointMenu",
        props: ["point"],

        methods: {
            
            linkTo(path)
            {
                document.getElementById(path).scrollIntoView(
                    {
                        behavior: "smooth", 
                        block: "start"
                    }
                    );
            }
        }
    }

</script>


<style lang="scss" scoped>
    @import './../assets/index.scss';

    .point-menu
    {
        font-family: 'Roboto';
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