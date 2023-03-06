<script>
export default{
  data(){
    return {
    posts:[
      {id:1, title: 'Java Script', body: 'описание поста 1'},
      {id:2, title: 'Java Script 115', body: 'описание поста 2'},
      {id:3, title: 'Java Scriptgffg', body: 'описание поста 3'},
      {id:4, title: 'Java Script 66464', body: 'описание поста 4'}
    ],
    title: '',
    body: ''
    }
  },
  methods:{
    CreatePost(event){
  const newPost = {
    id: Date.now(),
    title: this.title,
    body:this.body
  }
  this.posts.push(newPost);
  this.body = '',
  this.title = ' '
}
  }
}

var app = new Vue({
  el: '.app',
})
</script>

<template>
<div class="app">
  <form @submit.prevent>
    <h4>Название поста</h4>
    <input v-bind:value="title" @input="title = $event.target.value" class="inputArea"  type="text" placeholder="name">
    <input v-bind:value="body"  @input="body = $event.target.value" class="inputArea" type="text" placeholder="information">
    <button class="but" @click="CreatePost">Создать</button>
  </form>
  <div class="post" v-for="post in posts">
    <div><strong>Название: </strong> {{ post.title }}</div>
    <div><strong>Описание: </strong> {{ post.body }}</div>
  </div>
</div>
</template>

<style>
.post{
  border: 3px solid blue;
  padding: 15px;
  margin-top: 5px;
}

.app{
  margin: 10px;
}

form{
  display: flex;
  flex-direction: column;
}

.inputArea{
  width: 100%;
  border: 1px solid blue;
  padding: 15px;
  margin-top: 5px;
}

.but{
  align-self: flex-end;
  margin-top: 15px;
  padding: 10px 15px;
  background: none;
  color: teal;
  border: 1px solid teal;
}
</style>
