<template>
<div class="wrap">
    <div class="text1">
        <div class="informCourse" v-for="item in oddItems">
            <p class="header">{{item.headerText}}</p>
            <p>{{ item.text }}</p>
        </div>
    </div>

    <div class="line"></div>

    <div class="text3">
        <div class="informCourse" v-for="item in evenItems">
            <p class="header">{{item.headerText}}</p>
            <p>{{ item.text }}</p>
        </div>
    </div>
</div>

</template>

<script>
export default{
    props: {
    evenItems: {
      type: Array,
      required: true,
    },
    oddItems: {
      type: Array,
      required: true,
    },
  },
}
</script>

<style lang="scss" scoped>
@import './../../assets/index.scss';
.wrap
{
    display: flex;
    flex-direction: row;
    text-align: center;
    align-items: center;
    justify-content: center;
    gap: 20px;

    .line{
        background-image: linear-gradient(94.26deg, #C89AFC 9.51%, #7C6AFA 90.23%);
        width: 6px;
        height: 95%;
        margin: 15px;

        @media (max-width: 450px) {
            display: none;
        }
    }

    .text1, .text3
    {
        display: flex;
        flex-direction: column;
        font-style: normal;
        color: #FFFFFF;
        gap: 15px;
        align-items: baseline;
        text-align: end;
        margin-top: 6%;
        .informCourse
        {
            font-weight: 400;
            font-size: 18px;
            line-height: 160%;
            width: 95%;
            display: flex;
            flex-direction: column;
            margin-bottom: 18%;
            .header
            {
                font-weight: 400;
            font-size: 14px;
            opacity: 0.5;
            padding-bottom: 15px;
            }
        }
    }

    .text3
    {
        text-align: start;
        margin-left: 2%;
    }

   
}
</style>