<template>
<div class="container">
    <div class="nameObBlock">
        <div class="photo"><img src="../../assets/Images/icon-heading_3.svg" alt=""></div>
        <div class="text">Ваши преподаватели</div>
    </div>

    <div class="infAboutTeacher">
        <ListOfTeacher v-for="teach of informationTeacher"
        :urlPhoto = teach.urlPhoto
        :nameOfTeacher = teach.nameOfTeacher
        :positionOfTeacher = teach.positionOfTeacher
        />
    </div>
</div>
</template>

<script>
import ListOfTeacher from './ListOfTeacher.vue';

export default
{
    components:{
        ListOfTeacher
    },        
    props: ['informationTeacher']
}
</script>

<style lang="scss" scoped>
  @import '../../assets/index.scss';
.container
{
    display: flex;
    flex-direction: column;
    font-style: normal;
    font-weight: 700;
    font-size: 48px;
    color: #FFFFFF;
    padding: 5px 80px;

    .nameObBlock{
        display: flex;
        flex-direction: row;
        align-items: center;
        justify-content: flex-start;
        text-align: center;
    }

    .infAboutTeacher
    {
        display: flex;
        flex-direction: row;
        justify-content: center;
        gap: 13%;
        
    }
}

</style>