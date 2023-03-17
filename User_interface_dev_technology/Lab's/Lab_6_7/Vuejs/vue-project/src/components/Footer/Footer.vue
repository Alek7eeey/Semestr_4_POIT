<template>
<div class="wrapperFooter">
    <div class="head">Статьи каждую неделю</div>
    <div class="inf">Больше 90% учеников прошли полный курс и смогли<br> собрать свой первый компьютер</div>
    <div class="ConnectWithUs">
        <div class="email">
            <input type="email" placeholder="E-mail" v-model="login2" @input="validateEmail"/>
            <span class="messageError" v-if="emailError" style="color: red">{{ emailError }}</span>
            <Button class="btn" :text="textButton" @click="boxWithInf">Отправить</Button>
        </div>
        <div class="icons">
           <a :href="href1"><div><img :src="image1" alt=""></div></a> 
            <a :href="href2"><div><img :src="image2" alt=""></div></a>
            <a :href="href3"><div><img :src="image3" alt=""></div></a>
            <a :href="href4"><div><img :src="image4" alt=""></div></a>
        </div>
    </div>
</div>
</template>

<script>

export default
{
    props: ["image1", "image2", "image3", "image4", "href1", "href2", "href3", "href4"],

    data() {
        return {
            textButton: "Подписаться",
            login2: " ",
            emailError: "",
            isTrue: false
        }
    },

    methods: {

        boxWithInf() {
            if(this.login2 === " ") alert("Вы ничего не ввели!");
            else if(this.isTrue){
        alert("E-mail: " + this.login2);
        this.login2 = "";
            }
    },

    validateEmail() {
      const regex = /[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]/;
      if (!regex.test(this.login2) && this.login2 != "") 
      {
        this.emailError = "Введите корректный адрес электронной почты";
        this.isTrue = false;
      }
    else 
       {
        this.emailError = "";
        this.isTrue = true;
      }
    }
    }
}
</script>

<style lang="scss" scoped>
@import './../../assets/index.scss';
.wrapperFooter{
    display: flex;
    flex-direction: column;
    text-align: center;
    justify-content: center;
    font-style: normal;
    color: #FFFFFF;
    padding: 0 80px 30px;
    gap: 35px;

    .messageError
    {
        display: flex;
        text-align: center;
        justify-content: center;
    }
    .head
    {
        font-weight: 700;
        font-size: 48px;
        line-height: 140%;
    }
    .inf{
        opacity: 0.5;
        font-weight: 400;
        font-size: 16px;
        line-height: 160%;
    }

    .ConnectWithUs
    {
        display: flex;
        flex-direction: column;
        align-items: center;
        gap: 35px;
    
        .email
        {
            color: #FFFFFF;
            position: relative;
            @media (max-width: 500px) {
                @include flexer(20px);
                flex-direction: column;
            }
        }
        .email input{
            //opacity: 0.5;
            border-radius: 50px 50px 50px 50px;
            width: 433px;
            flex: 1;
            color: white;
            height: 42px;
            padding: 10px 30px;
            border: none;
            margin-left: 15px;
            background-color: RGBA(255,255,255,0.1);
            @media (max-width: 500px) {
                max-width: 433px;
                width: 100%;
            }
        }

        .email button{
            background: linear-gradient(94.78deg, #DF5950 11.19%, #451046 93.72%);
            border-radius: 50px;
            padding: 10px 30px;
            gap: 10px;
            color: white;
            font-weight: 700;
            font-size: 16px;
            line-height: 150%;
            max-width: 190px;
            width: 100%;
            height: 44px;
            z-index: inherit;
            position: absolute;
            right: -110px;
            top: -1px;

            @media (max-width: 500px) {
                position: static;
            }
        }

        button:hover{
                box-shadow: 1px 1px rgb(175, 120, 19);
            }
    }

    .icons{
    display: flex;
    flex-direction: row;
    gap: 30px;
    flex-wrap: wrap;
    @media (max-width: 480px) {
        justify-content: center;
    }
    }
    .icons div{
   display: flex;
    width: 50px;
    height: 50px;
    border-radius: 50%;
    /*кроссбраузерность */
    -moz-border-radius: 50%;
    -webkit-border-radius: 50%;
    -khtml-border-radius: 50%;
    background: linear-gradient(94.26deg, #C89AFC 9.51%, #7C6AFA 90.23%);
    text-align: center;
    justify-content: center;
    
    img{
        width: 60%;
    }

}
}
</style>