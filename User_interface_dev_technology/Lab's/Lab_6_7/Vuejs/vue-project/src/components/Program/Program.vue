<template>
    <div class="wrapper">
            <div class="someInf">
                <img src="../src/assets/Images/icon-heading_2.svg" alt="">
                    <div class="ProgramOfEducation">
                    <div class="th">Программа обучения</div>
                    <div class="t">Больше 90% учеников прошли полный курс и смогли собрать свой первый компьютер</div>
                    </div>
            </div>

            <div class="moreInf">
                <tableInformation :even-items="evenItems" :odd-items="oddItems"/>
            </div>
</div>
</template>

<script>
import tableInformation from "./ProgramTable.vue";
export default
{
    components:{
        tableInformation
    },
    
    props: {
    items: {
      type: Array,
      required: true,
    },
  },
  computed: {
    evenItems() {
      return this.items.filter((item) => item.id % 2 === 0);
    },
    oddItems() {
      return this.items.filter((item) => item.id % 2 !== 0);
    },
  },
}
</script>

<style lang="scss" scoped>
  @import '../../assets/index.scss';

  .wrapper
  {
    display: flex;
    flex-direction: column;
    gap: 60px;
  }

  .moreInf
  {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
  }
.someInf{
    display: flex;
    flex-direction: column;
    text-align: center;
    justify-content: center;
    align-items: center;
  }
  .someInf img{
    width: 11%;
  }
  .ProgramOfEducation
  {
    display: flex;
    flex-direction: column;
            font-style: normal;
            font-weight: 700;
            font-size: 48px;
            color: #FFFFFF;
            text-align: center;
            gap: 18px;
            align-items: center;
    .t{
      font-size: 16px;
      font-weight: 400;
      line-height: 160%;
      opacity: 0.5;
      width: 70%;
    }
  }
</style>