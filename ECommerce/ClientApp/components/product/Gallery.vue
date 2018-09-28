<template>
  <div class="gallery" @click="close">
    <span @click.stop="prev">
      <i class="fas fa-chevron-circle-left fa-3x prev"/>
    </span>

    <div class="slide" @click.stop="next">
      <transition name="fade" mode="out-in">
        <img class="img-fluid"
          :src="images[index]"
          :key="images[index]"
          :alt="images[index]" />
      </transition>
    </div>

    <span @click.stop="next">
      <i class="fas fa-chevron-circle-right fa-3x next"/>
    </span>
  </div>
</template>