<template>
        <div class="ph">
            <img v-for="index in 8" 
                 :src="imageUrl" 
                 alt="Image">
        </div>
</template>

<script>

export default {
  props: {
    imageUrl: {
      type: String,
      required: true
    }
  }
}

</script>

<style lang="scss" scoped>
@import './../../assets/index.scss';
.ph img{
    width: 198px;
    height: 93px;
    //border: 1px solid rgba(255, 255, 255, 1);
}

.ph{
    @include flexer(100px);
    flex-wrap: wrap;
}
/*.ph img:nth-child(1){
  border-top: none;
  border-left: none;
 
  border-right: none;
}
.ph img:nth-child(2){
  border-top: none;

  border-right: none;
}
.ph img:nth-child(3){
  border-top: none;

  border-right: none;
}
.ph img:nth-child(4){
  border-top: none;
  border-right: none;

}
.ph img:nth-child(5){
  border-bottom: none;
  border-left: none;
  border-right: none;
}
.ph img:nth-child(6){
  border-bottom: none;
  border-right: none;
}
.ph img:nth-child(7){
  border-bottom: none;
  border-right: none;
}
.ph img:nth-child(8){
  border-bottom: none;
  border-right: none;
}*/
</style>