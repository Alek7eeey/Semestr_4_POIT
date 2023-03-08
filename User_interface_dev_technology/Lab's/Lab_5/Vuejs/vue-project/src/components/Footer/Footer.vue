<template>
<div class="wrapper">
    <div class="head">Статьи каждую неделю</div>
    <div class="inf">Больше 90% учеников прошли полный курс и смогли<br> собрать свой первый компьютер</div>
    <div class="ConnectWithUs">
        <div class="email">
            <input type="email" placeholder="E-mail">
            <button>Подписаться</button>
        </div>
        <div class="icons">
            <div><img :src="image1" alt=""></div>
            <div><img :src="image2" alt=""></div>
            <div><img :src="image3" alt=""></div>
            <div><img :src="image4" alt=""></div>
        </div>
    </div>
</div>
</template>

<script>
export default
{
    props: ["image1", "image2", "image3", "image4"]
}
</script>

<style lang="scss" scoped>

.wrapper{
    display: flex;
    flex-direction: column;
    text-align: center;
    justify-content: center;
    font-style: normal;
    color: #FFFFFF;
    padding: 0 80px 30px;
    gap: 35px;

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
            
        }
        .email input{
            //opacity: 0.5;
            border-radius: 50px 50px 50px 50px;
            width: 353px;
            height: 42px;
            padding: 10px 30px;
            border: none;
            margin-left: 15px;
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
            width: 190px;
            height: 44px;
            margin-left: -35px;
        }

        button:hover{
                box-shadow: 1px 1px rgb(175, 120, 19);
            }
    }

    .icons{
    display: flex;
    flex-direction: row;
    gap: 30px;
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