<template>
    <div class="start-info-block">

        <div class="percent">
            {{ percent }}
        </div>

        <div class="progress-bar">
            <div class="block-progress" 
                :style="{ height: progress_count } ">

            </div>
        </div>

        <div class="context">
            {{ context }}
        </div>

    </div>
</template>

<script>

export default {
    props: ["percent", "progress_count", "context"],
    name: "StartInfoBlock",
}

</script>

<style lang="scss" scoped>
@import './../../assets/index.scss';

.start-info-block
{
    display: flex;
    flex-direction: column;

    @media (max-width: 400px) {
        width: 100% !important;
    }

    .percent
    {
        height: 50px;
        font-family: 'Roboto';
        font-style: normal;
        font-weight: 700;
        font-size: 36px;
        line-height: 140%;
        color: #FFFFFF;
    }

    .progress-bar
    {
        @include flexer(0);
        height: 80px;
        width: 100%;
        margin: 15px 0;

        .block-progress
        {
            width: 105%;
        }
    }

    .context
    {
        font-family: 'Roboto';
        font-style: normal;
        font-weight: 400;
        font-size: 14px;
        line-height: 160%;
        color: #FFFFFF;
        opacity: 0.5;
        width: 90%;
    }
}

</style>
