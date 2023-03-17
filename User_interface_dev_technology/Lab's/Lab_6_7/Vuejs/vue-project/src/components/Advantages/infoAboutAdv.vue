<template>
<div class="rowInf">
    <div class="image">
        <img :src="image" alt="advantages">
    </div>
    <div class="HeaderText">
        {{ headerText }}
    </div>
    <div class="text">
        {{ text }}
    </div>
</div>
</template>

<script>
export default
{
    props: ["image", "headerText", "text"],
    name: "InfAboutAdv"
}

</script>

<style lang="scss" scoped>
@import './../../assets/index.scss';
.rowInf{
    max-width: 400px;
    width: 100%;
    display: flex;
    flex-direction: column;
    gap: 13px;
    text-align: center;

    .image{
        width: 100px;
        height: 100px;
        text-align: center;
        width: 100%;
        height: 50%;
        margin-bottom: 16px;
    }

    .HeaderText{
        font-family: 'Roboto', sans-serif;
        font-style: normal;
        font-weight: 500;
        font-size: 24px;
        color: #FFFFFF;
        padding: 15px;
        width: 100%;
        text-align: center;
        height: 50%;
    }

    .text{
        font-family: 'Roboto', sans-serif;
        font-style: normal;
        font-weight: 400;
        font-size: 16px;
        color: #FFFFFF;
        width: 100%;
        text-align: center;
    }
}

</style>