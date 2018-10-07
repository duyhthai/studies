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


<script>
export default {
  props: {
    images: {
      type: Array,
      required: true
    },
    initial: {
      type: Number,
      required: true
    }
  },
  data() {
    return {
      index: 0
    };
  },
  created() {
    this.index = this.initial;
    window.addEventListener("keyup", this.onKeyup);
  },
  beforeDestroy() {
    window.removeEventListener("keyup", this.onKeyup);
  },
  methods: {
    onKeyup(event) {
      switch (event.keyCode) {
        case 27:
          this.close();
          break;
        case 37:
          this.prev();
          break;
        case 39:
          this.next();
          break;
      }
    },
    next() {
      if (this.index < this.images.length - 1) {
        this.index++;
      } else {
        this.index = 0;
      }
    },
    prev() {
      if (this.index > 0) {
        this.index--;
      } else {
        this.index = this.images.length - 1;
      }
    },
    close() {
      this.$emit("close");
    }
  }
};
</script>


<style>
</style>
