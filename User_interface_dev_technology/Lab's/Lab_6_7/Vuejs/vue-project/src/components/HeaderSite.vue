
<template>
    <header class='header-site'>
        <img src="./../assets/Images/logo.svg"/>

        <NavMenu :points="points"
                 :burger="this.burger"/>

        <button class="burger-btn" 
                v-on:click="toggleBurger"
                :style="{ display: (!this.burger ? 'none' : 'flex') }">

          <span class="burger-btn__line"></span>
          <span class="burger-btn__line"></span>
          <span class="burger-btn__line"></span>
          
        </button>

        <div class="burger-menu"
             :style="{ display: this.showMenu ? 'flex' : 'none' }">

             <NavMenu :points="points"
                      :burger="!this.burger"/>

        </div>

    </header>
</template>

<script>
    import NavMenu from './NavMenu/NavMenu.vue';
    import PointMenu from './PointMenu.vue';

    export default {
        props: ["points"],
        components: { PointMenu, NavMenu },

        data() {
            return { 
                burger: false,
                showMenu: false
            }
        },

        mounted() {
            document.body.onload = document.body.onresize = this.changeSize;
        },

        methods: {
            changeSize() {
                this.burger = document.body.clientWidth < 1300;

                if(!this.burger) {
                    this.showMenu = false;
                    const btn = document.querySelector('.burger-btn');
                    btn?.classList.remove('open');
                }

                console.log(this.burger)
            },

            toggleBurger() {
                const btn = document.querySelector('.burger-btn');
                this.showMenu = (Boolean)(btn?.classList.toggle('open'));

                document.body.style.overflow = this.showMenu ? "hidden" : "auto";
            }

        },
    }
</script>


<style lang="scss">


    .burger-menu {
        position: absolute;
        flex-direction: column;
        justify-content: center;
        gap: 60px;
        align-items: center;
        width: 100%;
        height: 100vh;
        background-color: #121212;
        left: 0;
        top:0;
        z-index: 50;
        .header-menu {
            flex-direction: column;
            align-items: center;
            gap: 15px;
        }
    }

    @mixin flexer($value : 0)
    {
        display: flex;
        justify-content: center;
        align-items: center;
        gap: $value;
    }

    @mixin flexerSB
    {
        display: flex;
        justify-content: space-between;
        align-items: center;
    }

    .header-menu {
            @include flexer;
            flex-wrap: wrap;
            z-index: 100;
            .point-menu
            {
                width: 136px;
                height: 40px;
                @include flexer;
            }
         }

        .toCabinet
        {
            width: 183px;
            height: 44px;
            background: linear-gradient(94.26deg, #C89AFC 9.51%, #7C6AFA 90.23%);
            border-radius: 50px;
            display: flex;
            flex-direction: row;
            justify-content: center;
            align-items: center;
            padding: 10px 30px;
            gap: 10px;

            color: white;
            outline: none;
            border: none;
            font-style: normal;
            font-weight: 400;
            font-size: 16px;
            line-height: 150%;
        }
    .header-site {
        @include flexerSB;
        width: 100%;

        img {
            z-index: 100;
        }

}

.burger-btn {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  width: 30px;
  height: 20px;
  background-color: transparent;
  border: none;
  padding: 0;
  cursor: pointer;
  z-index: 100;

  span {
    border-radius: 2px;
}

  @media (min-width: 1100px) {
    span {
        background-color: #ee2222;
    }
  }
}

.burger-btn__line {
  display: block;
  width: 100%;
  height: 2px;
  background-color: #fff;
  transition: transform 0.3s ease-out;
}

.burger-btn__line:first-child {
  transform-origin: top;
}

.burger-btn__line:last-child {
  transform-origin: bottom;
}

.burger-btn.open .burger-btn__line:first-child {
  transform: translateY(10px) rotate(45deg);
}

.burger-btn.open .burger-btn__line:last-child {
  transform: translateY(-10px) rotate(-45deg);
}

.burger-btn.open .burger-btn__line:nth-child(2) {
  opacity: 0;
}


</style>