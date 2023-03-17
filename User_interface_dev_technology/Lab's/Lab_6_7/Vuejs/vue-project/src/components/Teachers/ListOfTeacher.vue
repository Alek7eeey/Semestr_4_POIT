<template>
    <div class="teacher">
    <div class="phOfTeacher"><img :src="urlPhoto" alt=""></div>
        <div class="name">{{ nameOfTeacher }}</div>
        <div class="position">{{ positionOfTeacher }}</div>
        <div class="description" v-show="showDescription">{{ description }}</div>
        <div class="button">
            <button @click="$event => showDescription = !showDescription">{{ showDescription ? "Скрыть" : "Биография" }}</button>
        </div>
    </div>
</template>

<script>
export default
{
    props: ["urlPhoto", "nameOfTeacher", "positionOfTeacher", "description"],
    data() {
        return {
            showDescription: false
        }
    }
}
</script>

<style lang="scss" scoped>
  @import '../../assets/index.scss';

  .teacher{
    display: flex;
    flex-direction: column;
    text-align: center;
    font-style: normal;
    color: #FFFFFF;

    .description {
        font-size: 14px;
        font-weight: 300;
    }

    .name{
    font-weight: 500;
    font-size: 24px;
    line-height: 140%;
    padding: 10px;
    }
    .position
    {
        opacity: 0.8;
        font-size: 16px;
        line-height: 160%;
        font-weight: 400;
        padding: 6px;
    }
    .button button{
        width: 143px;
        height: 44px;
        border: 1px solid #FFFFFF;
        box-shadow: 2px 1px wheat;
        border-radius: 50px;
        font-weight: 400;
        font-size: 16px;
        line-height: 150%;
        color: white;
        background-color: black;
    }

    .button button:hover
    {
        box-shadow: 2px 2px sandybrown;
        scale: 1.1;
    }
  }

</style>