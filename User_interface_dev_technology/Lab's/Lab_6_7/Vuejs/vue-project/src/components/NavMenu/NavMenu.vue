<template>
    <ul class='header-menu'  
            :style="{ display: (burger ? 'none' : 'flex') }">

            <PointMenu
                v-for="point of points"
                :point="point"
            />

        </ul>

        <button class="toCabinet"
                :style="{ display: (this.burger ? 'none' : 'flex') }">Зайти в кабинет</button>
</template>

<script>
import PointMenu from '../PointMenu.vue';

    export default {
    props: ["burger", "points"],
    components: { PointMenu }
}
</script>

<style lang="scss">

</style>