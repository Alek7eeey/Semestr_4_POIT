
<template>
    <div class="time-block">
        <span class="count">{{ data.count }}</span>
        <span class="system">{{ data.system }}</span>
    </div>
</template>

<script lang="ts">

    export default {
        props: ["data"],
        name: "TimeBlock"
    }

</script>

<style lang="scss" scoped>

.time-block
{
    width: 102px;
    height: 112px;

    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    gap: 1px;
    background: #12121289;

    .count{
        font-family: 'Roboto';
        font-style: normal;
        font-weight: 700;
        font-size: 36px;
        line-height: 140%;
        color: #FFFFFF;
    }

    .system
    {
        font-family: 'Roboto';
        font-style: normal;
        font-weight: 400;
        font-size: 16px;
        line-height: 140%;
        text-align: center;
        color: #FFFFFF;
        opacity: 0.4;
    }
}

</style>
